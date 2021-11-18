using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class ChanceCard
    {
        /// <summary>
        /// TODO: Comment.
        /// </summary>
        
        #region Properties

        public int Id { get; }
        public string Content { get; }
        public int Value { get; }
        public int MoveIndex { get; }

        #endregion

        #region Methods

        public ChanceCard(int id, string content, int value, int newIndex)
        {
            Id = id;
            Content = content;
            Value = value;
            MoveIndex = newIndex;
        }
        
        public override string ToString()
        {
            return $"{Content}";
        }

        #endregion
    }
}