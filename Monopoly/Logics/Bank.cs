using System;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.PlayerFlyweight.Static;
using Monopoly.UI;

namespace Monopoly.Logics
{
    public class Bank
    {
        private readonly Property _property;
        private readonly WalletCalculator _calculator = new ();
        private readonly GameManager _manager = GameManager.GetInstance();
        private readonly PlayerGenerator _playerGenerator = PlayerGenerator.GetInstance();
        private bool _taxRaise;

        public Bank(Property property)
        {
            _property = property;
        }

        public Bank()
        {
        }

        public void BuyProperty(int playerId)
        {
            if(CreditCheck(playerId, _property.BuyPrice))
            {
                _calculator.SubtractBalance(playerId, _property.BuyPrice);
                _property.SetAvailability(false);
                _property.SetOwner(playerId);
                ConsoleOutput.PrintNewLine();
                ConsoleOutput.Print("Congratulations on your new property!", ConsoleColor.Cyan);
            }
            else
            {
                ConsoleOutput.PrintNewLine();
                ConsoleOutput.Print("You don't have enough money to purchase this property!", ConsoleColor.Red);
            }
            
        }

        public void RentProperty(int playerId, int ownerId)
        {
            if (CreditCheck(playerId, _property.RentPrice))
            {
                _calculator.AddBalance(ownerId, _property.RentPrice);
                _calculator.SubtractBalance(playerId, _property.RentPrice);
            }
            else
            {
                Bankrupt(playerId);
                _calculator.AddBalance(ownerId, _property.RentPrice);
            }
            
        }

        /// <description>
        /// The chance cards that withdraw money from the account are already set to negative numbers,
        /// so all calculation is done with Add () since number1 + (-number2) == number1 - number2.
        /// </description>

        public void ChanceHandler(int playerId, int value)
        {
            if (value > 0)
            {
                _calculator.AddBalance(playerId, value);
            }
            else if (CreditCheck(playerId, value))
                _calculator.AddBalance(playerId, value);
            else
                Bankrupt(playerId);
        }

        private bool CreditCheck(int playerId, int price)
        {
            CheckPlayerRich();

            int playerBalance = _playerGenerator.Get(playerId).Wallet.Balance;
            int res;

            if (price < 0)
            {   
                // price is negative, so n + (-n).
                res = playerBalance + price;
            }
            else
            {
                res = playerBalance - price;
            }
            
            
            if (res > 0)
                return true;

            return false;
        }

        private void CheckPlayerRich()
        {
            bool playerRich = true;

            foreach (var player in _playerGenerator.Players)
            {
                if (player.Value.Wallet.Balance < 800 && player.Value.Wallet.Balance > 1)
                {
                    playerRich = false;
                }
            }

            Console.WriteLine(playerRich);

            if (!_taxRaise && playerRich)
            {
                int raiseValue = 200;
                var mapSquares = _manager.Map.MapSquares;
                foreach (var square in mapSquares)
                {
                    if (square.Value is Property property)
                    {
                        property.SetBuyPrice(property.BuyPrice + raiseValue);
                        property.SetRentPrice(property.RentPrice + raiseValue);
                        _manager.Map.MapSquares[square.Key] = property;
                    }
                }

                _taxRaise = true;
            }
        }

        private void Bankrupt(int playerId)
        {
            PlayerGenerator playerGenerator = PlayerGenerator.GetInstance();

            ConsoleOutput.Print("You don't have enough money to cover your rent!", ConsoleColor.Red);
            ConsoleOutput.Print("You are officially bankrupt!", ConsoleColor.Red);

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
    }
}