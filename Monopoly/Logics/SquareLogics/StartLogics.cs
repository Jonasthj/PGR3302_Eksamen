using System;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.UI;

namespace Monopoly.Logics.SquareLogics
{
    public class StartLogics : AbstractLogics
    {
        private const int Collect = 100;

        public override void Handle(ISquare square, int playerId)
        {
            ConsoleOutput.Print(square.ToString(), ConsoleColor.White);
            
            WalletCalculator calculator = new();
            calculator.AddBalance(playerId, Collect);
        }
    }
}