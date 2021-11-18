
namespace Monopoly.Logics.CardFactory.Classes
{
    public class ChanceCard
    {
        /// <summary>
        /// 
        /// </summary>
        
        #region Properties

        private int Id { get; }

        private string Content { get; }
        public int Value { get; }
        public int MoveIndex { get; }

        #endregion

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
    }
}