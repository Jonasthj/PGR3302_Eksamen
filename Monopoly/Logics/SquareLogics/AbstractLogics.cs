using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.SquareLogics
{
    public abstract class AbstractLogics
    {
        public abstract void Handle(ISquare square, int playerId);
    }
}