using Monopoly.Logics.CardFactory.Abstract;
using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class CreatePrison : CreateSquare
    {
        public override ISquare BuildSquare()
        {
            return new Prison();
        }
    }
}