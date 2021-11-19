using System;
using System.Collections.Generic;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.SquareLogics
{
    public class ChanceLogics
    {
        private readonly GameManager _manager = GameManager.GetInstance();
        
        #region Methods
        
        public ChanceCard HandleChance(ISquare square, int playerId)
        {
            var chanceCard = PickChanceCard(square);
            return chanceCard;
        }

        public void CheckPlayerShouldMove(int playerId, ChanceCard chanceCard)
        {
            if (chanceCard.MoveIndex >= 0)
            {
                BoardMap map = _manager.Map;
                map.Players[playerId] = chanceCard.MoveIndex;

                _manager.SquareController(chanceCard.MoveIndex, playerId);
            }
        }

        private ChanceCard PickChanceCard(ISquare square)
        {
            Chance chance = (Chance) square;

            // Retrieve all chanceCards.
            List<ChanceCard> cardsList = chance.ChanceCards;
            // Pick one.
            ChanceCard chanceCard = cardsList[new Random().Next(cardsList.Count)];
            chance.SetChanceCard(chanceCard);

            return chanceCard;
        }
        
        #endregion
    }
}