using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class ChanceCard : IGetFields, IChanceCard 
    {
        #region Properties

        private int Id { get; }
        private string Content { get; }
        private int Value { get; }
        private int MoveIndex { get; }

        #endregion

        #region Constructors

        public ChanceCard(int id, string content, int value, int newIndex)
        {
            Id = id;
            Content = content;
            Value = value;
            MoveIndex = newIndex;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"{Content}";
        }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Content;
        }

        public int GetValue()
        {
            return Value;
        }

        public int GetMoveIndex()
        {
            return MoveIndex;
        }

        #endregion
    }
}