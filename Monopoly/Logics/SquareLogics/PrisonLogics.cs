using System;
using Monopoly.Flyweight;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.PlayerFlyweight.Static;
using Monopoly.UI;

namespace Monopoly.Logics.SquareLogics
{
    public class PrisonLogics : AbstractLogics
    {
        public override void Handle(ISquare square, int playerId)
        {
            ConsoleOutput.Print(square.ToString(), ConsoleColor.White);

            Player player = PlayerGenerator.GetInstance().Get(playerId);

            if (player.InPrison)
                player.InPrison = false;
            else if (!player.InPrison)
                player.InPrison = true;
        }
    }
}