using Monopoly.Logics.CardFactory.Interface;
using Monopoly.UI;

namespace Monopoly.Logics.SquareLogics
{
    public class PropertyLogics : AbstractLogics
    {
        public override void Handle(ISquare square, int playerId)
        {
            ConsoleOutput.Print(square.ToString());
        }
    }

}