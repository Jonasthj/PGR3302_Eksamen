namespace Monopoly.Factory.Classes
{
    public class ChanceCard
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
            return $"Id: {Id}," +
                   $"Content: {Content}," +
                   $"Value: {Value}," +
                   $"MoveIndex: {MoveIndex}";
        }

        #endregion
    }
}