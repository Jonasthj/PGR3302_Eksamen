using System;
using System.Collections.Generic;
using Monopoly.Flyweight;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.PlayerFlyweight.Static;
using Monopoly.UI;

namespace Monopoly.Logics.SquareLogics
{
    public class ChanceLogics: AbstractLogics
    {
        public override void Handle(ISquare square, int playerId)
        {
            Chance chance = (Chance)square;

            // Retreive all chanceCards.
            List<ChanceCard> cardsList = chance.GetChanceCards();
            // Pick one.
            ChanceCard chanceCard = cardsList[new Random().Next(cardsList.Count)];
            chance.SetChanceCard(chanceCard);
            
            ConsoleOutput.Print(square.ToString());

            WalletCalculator calculator = new WalletCalculator();
            calculator.AddBalance(playerId, chanceCard.GetValue());

            if (chanceCard.GetMoveIndex() >= 0)
            {
                // TODO: make player move.   
            }
            
            Console.WriteLine(chanceCard.GetId());

        }
    }
}