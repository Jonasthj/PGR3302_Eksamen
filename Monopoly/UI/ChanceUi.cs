using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.SquareLogics;

namespace Monopoly.UI
{
    public class ChanceUI: AbstractLogics
    {
        private readonly ChanceLogics _chanceLogics = new();
        
        public override void Handle(ISquare square, int playerId)
        {
            BankUI bankUI = new ();
            
            ChanceCard chanceCard = _chanceLogics.HandleChance(square, playerId);
            ConsoleOutput.Print(square.ToString());
            
            bankUI.ChanceHandler(playerId, chanceCard.Value);
            _chanceLogics.CheckPlayerShouldMove(playerId, chanceCard);
            
            ConsoleOutput.PrintEnter();
            ConsoleInput.ReadKey();
        }
    }
}