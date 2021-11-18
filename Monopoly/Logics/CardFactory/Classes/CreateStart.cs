using Monopoly.Logics.CardFactory.Abstract;
using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class CreateStart : CreateSquare
    {
        public override ISquare BuildSquare()
        {
            return new Start();
        }
    }
}