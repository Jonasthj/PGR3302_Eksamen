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
            calculator.AddBalance(playerId, chanceCard.Value);

            if (chanceCard.MoveIndex >= 0)
            {
                BoardMap map = BoardMap.GetInstance();
                map.Players[playerId] = chanceCard.MoveIndex;
                
                GameManager manager = new GameManager();
                manager.SquareController(chanceCard.MoveIndex, playerId);
            }
        }
    }
}