using System.Collections;
using System.Collections.Generic;
using Monopoly.Factory.Abstract;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Factory.Classes
{
    public class CreateChance : CreateSquare
    {
        #region Fields
        
        private readonly int _id;
        private readonly List<ChanceCard> _chanceList;
        public CreateChance(int id, List<ChanceCard> chanceList)
        {
            _id = id;
            _chanceList = chanceList;
        }
        
        #endregion

        #region Overrides
        
        public override ISquare BuildSquare()
        {
            return new Chance(_id, _chanceList);
        }

        #endregion
    }
}