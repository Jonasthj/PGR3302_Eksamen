using System;
using Monopoly.Flyweight;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.PlayerFlyweight.Static;
using Monopoly.UI;

namespace Monopoly.Logics.SquareLogics
{
    public class StartLogics : AbstractLogics
    {
        private int _collect = 100;
        
        public override void Handle(ISquare square, int playerId)
        {
            ConsoleOutput.Print(square.ToString(), ConsoleColor.White);
            
            WalletCalculator calculator = new();
            calculator.AddBalance(playerId, _collect);
        }
    }
}