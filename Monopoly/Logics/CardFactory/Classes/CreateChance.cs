using System.Collections.Generic;
using Monopoly.Logics.CardFactory.Abstract;
using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class CreateChance : CreateSquare
    {
        private readonly int _id;
        private readonly List<ChanceCard> _chanceList;
        
        public CreateChance(int id, List<ChanceCard> chanceList)
        {
            _id = id;
            _chanceList = chanceList;
        }

        public override ISquare BuildSquare()
        {
            return new Chance(_id, _chanceList);
        }
    }
}