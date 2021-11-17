using Monopoly.Flyweight;
using Monopoly.Logics.PlayerFlyweight.Static;

namespace Monopoly.Logics
{
    public class WalletCalculator
    {
        private PlayerGenerator _generator = PlayerGenerator.GetInstance();
        public int CheckBalance(int playerId)
        {
            Player player = _generator.Get(playerId);
            
            return player.Wallet.Balance;
        }

        public void AddBalance(int playerId, int amount)
        {
            Player player = _generator.Get(playerId);

            player.SetWallet(new Wallet(player.Wallet.Balance + amount));
        }

        public void SubtractBalance(int playerId, int amount)
        {
            Player player = _generator.Get(playerId);
            
            player.SetWallet(new Wallet(player.Wallet.Balance - amount));
        }
    }
}