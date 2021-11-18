using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.SquareLogics;

namespace Monopoly.UI
{
    public class ChanceUI: AbstractLogics
    {
        private readonly ChanceLogics _chanceLogics = new();
        
        public override void Handle(ISquare square, int playerId)
        {
            ConsoleOutput.Print(square.ToString());
            _chanceLogics.HandleChance(square, playerId);

            ConsoleOutput.PrintEnter();
            ConsoleInput.ReadKey();
        }
    }
}