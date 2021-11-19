using Monopoly.Logics.PlayerFlyweight.Abstract;
using Monopoly.Logics.PlayerFlyweight.Singleton;

namespace Monopoly.Logics
{
    public class WalletCalculator
    {
        private readonly PlayerGenerator _generator = PlayerGenerator.GetInstance();

        public void AddBalance(int playerId, int amount)
        {
            Player player = _generator.Get(playerId);

            player.AddWallet(amount);
        }

        public void SubtractBalance(int playerId, int amount)
        {
            Player player = _generator.Get(playerId);
            
            player.SubtractWallet(amount);
        }
    }
}