using Monopoly.Logics.PlayerFlyweight.Abstract;
using Monopoly.Logics.PlayerFlyweight.Static;

namespace Monopoly.Logics.SquareLogics
{
    public class PrisonLogics
    {
        public void HandlePrisonLogic(int playerId)
        {
            Player player = PlayerGenerator.GetInstance().Get(playerId);

            if (player.InPrison)
                player.SetInPrison(false);
            else if (!player.InPrison)
                player.SetInPrison(true);
        }
    }
}