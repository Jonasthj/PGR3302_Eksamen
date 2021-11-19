using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.SquareLogics.Abstract
{
    public abstract class AbstractLogics
    {
        public abstract void Handle(ISquare square, int playerId);
    }
}