using Monopoly.Factory.Abstract;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class CreateStart : CreateSquare
    {
        private int _id;
        private string _name;

        public CreateStart(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public override ISquare BuildSquare()
        {
            return new Start(_id, _name);
        }
    }
}