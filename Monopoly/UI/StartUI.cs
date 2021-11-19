using System;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.SquareLogics;
using Monopoly.Logics.SquareLogics.Abstract;
using Monopoly.UI.ConsoleIO;

namespace Monopoly.UI
{
    public class StartUI : AbstractLogics
    {
        private readonly StartLogics _startLogics = new();

        public override void Handle(ISquare square, int playerId)
        {
            ConsoleOutput.Print(square.ToString(), ConsoleColor.White);
            _startLogics.HandleStartLogic(playerId);
            
        }
    }
}