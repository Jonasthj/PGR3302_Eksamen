using System.Collections.Generic;
using Monopoly.Logics.CardFactory.Classes;

namespace Monopoly.Logics.CardFactory.Interface
{
    public interface IChance
    {
        List<ChanceCard> GetChanceCards();

        void SetChanceCard(ChanceCard chanceCard);
    }
}