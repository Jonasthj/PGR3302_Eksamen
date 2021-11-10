using Monopoly.Factory.Abstract;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class CreatePrison : CreateSquare
    {
        private readonly int _id;
        private readonly string _name;

        public CreatePrison(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public override ISquare BuildSquare()
        {
            return new Prison(_id, _name);
        }
    }
}