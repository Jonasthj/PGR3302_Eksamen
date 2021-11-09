using Monopoly.Factory.Abstract;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class CreateProperty : CreateSquare
    {
        public override ISquare BuildSquare()
        {
            return new Property();
        }
    }
}