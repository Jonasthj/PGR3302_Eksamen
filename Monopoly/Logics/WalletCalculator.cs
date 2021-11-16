using System;
using Monopoly.Flyweight;

namespace Monopoly
{
    public class WalletCalculator
    {
        public int CheckBalance(int playerId)
        {
            Player player = PlayerGenerator.Get(playerId);
            
            return player.Wallet.Balance;
        }

        public void AddBalance(int playerId, int amount)
        {
            Player player = PlayerGenerator.Get(playerId);

            player.SetWallet(new Wallet(player.Wallet.Balance + amount));
        }

        public void SubtractBalance(int playerId, int amount)
        {
            Player player = PlayerGenerator.Get(playerId);
            
            player.SetWallet(new Wallet(player.Wallet.Balance - amount));
        }
    }
}