using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.SquareLogics;

namespace Monopoly.UI
{
    public class ChanceUi: AbstractLogics
    {
        private readonly ChanceLogics _chanceLogics = new();
        
        public override void Handle(ISquare square, int playerId)
        {
            _chanceLogics.HandleChance(square, playerId);
            ConsoleOutput.Print(square.ToString());

            ConsoleOutput.PrintEnter();
            ConsoleInput.ReadKey();
        }
    }
}