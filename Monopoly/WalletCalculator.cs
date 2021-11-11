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

        public void AddBalance()
        {
            
        }

        public void SubtractBalance()
        {
            
        }
    }
}