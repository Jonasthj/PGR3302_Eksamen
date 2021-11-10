using Monopoly.Factory.Abstract;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class CreatePrison : CreateSquare
    {
        public override ISquare BuildSquare()
        {
            return new Prison();
        }
    }
}