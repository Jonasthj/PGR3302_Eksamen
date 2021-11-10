using System.Collections;
using Monopoly.Factory.Abstract;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class CreateChance : CreateSquare
    {
        private readonly int _id;
        private readonly string _name;
        private readonly ArrayList _chanceList;
        public CreateChance(int id, ArrayList chanceList)
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