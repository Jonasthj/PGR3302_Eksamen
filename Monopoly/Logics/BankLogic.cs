using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.PlayerFlyweight.Static;

namespace Monopoly.Logics
{
    public class BankLogic
    {
        #region Fields
        
        private readonly WalletCalculator _calculator = new ();
        private readonly GameManager _manager = GameManager.GetInstance();
        private readonly PlayerGenerator _playerGenerator = PlayerGenerator.GetInstance();

        #endregion

        #region Methods

        public void Purchase(int playerId, Property property)
        {
            _calculator.SubtractBalance(playerId, property.BuyPrice);
            property.SetAvailability(false);
            property.SetOwner(playerId);
        }

        public void RentTransaction(int playerId, int ownerId, Property property)
        {
            _calculator.AddBalance(ownerId, property.RentPrice);
            _calculator.SubtractBalance(playerId, property.RentPrice);
        }

        public void BankPayout(int ownerId, Property property)
        {
            _calculator.AddBalance(ownerId, property.RentPrice);
        }

        /// <description>
        /// The chance cards that withdraw money from the account are already set to negative numbers,
        /// so all calculation is done with Add () since number1 + (-number2) == number1 - number2.
        /// </description>
        public bool Validate(int playerId, int value)
        {
            if (value > 0)
            {
                _calculator.AddBalance(playerId, value);
                return true;
            }
            if (PlayerHasCredit(playerId, value))
            {
                _calculator.AddBalance(playerId, value);
                return true;
            }

            return false;
        }

        public bool PlayerHasCredit(int playerId, int price)
        {
            int playerBalance = _playerGenerator.Get(playerId).Wallet.Balance;
            int res;

            if (price < 0)
            {
                // price is negative, so n + (-n).
                res = playerBalance + price;
            }
            else
                res = playerBalance - price;

            if (res > 0)
                return true;

            return false;
        }

        public bool CheckPlayersWealth()
        {
            foreach (var player in _playerGenerator.Players)
            {
                if (player.Value.Wallet.Balance is < 800 and > 1)
                {
                    return false;
                }
            }

            return true;
        }

        public void IncreaseTax(int raiseValue)
        {
            var mapSquares = _manager.Map.MapSquares;
            foreach (var square in mapSquares)
            {
                if (square.Value is Property property)
                {
                    int newBuy = property.BuyPrice + raiseValue;
                    int newRent = property.RentPrice + raiseValue;

                    property.SetBuyPrice(newBuy);
                    property.SetRentPrice(newRent);
                    _manager.Map.MapSquares[square.Key] = property;
                }
            }

            _manager.TaxRaise = true;
        }
        
        public void BlacklistPlayer(int playerId)
        {
            PlayerGenerator playerGenerator = PlayerGenerator.GetInstance();

            playerGenerator.Get(playerId).SetWallet(0);
            
            playerGenerator.Blacklist(playerId);
            ResetProperties(playerId);
        }

        private void ResetProperties(int playerId)
        {
            foreach (var square in _manager.Map.MapSquares)
            {
                // Convert square to property.
                if (square.Value is Property property)
                {
                    if (playerId == property.OwnerId)
                    {
                        property.SetOwner(0);
                        property.SetAvailability(true);

                        // CreateProperty create = new CreateProperty(property);
                        _manager.Map.MapSquares[square.Key] = property;
                    }
                }
            }
            _manager.Map.Players[playerId] = -1;
        }
        
        #endregion
    }
}