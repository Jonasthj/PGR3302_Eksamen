namespace Monopoly.Factory.Classes
{
    public class ChanceList
    {
        private string Content { get; }
        private int Value { get; }
        private int NewIndex { get; }

        public ChanceList(string content, int value, int newIndex)
        {
            Content = content;
            Value = value;
            NewIndex = newIndex;
        }

        public override string ToString()
        {
            return $"Content: {Content}," +
                   $"Value: {Value}," +
                   $"NewIndex: {NewIndex}";
        }
    }
}