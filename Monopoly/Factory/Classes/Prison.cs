using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Prison : ISquare
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public void PrintSquare()
        {
            throw new System.NotImplementedException();
        }
        
        public override string ToString()
        {
            return "Id: " + Id + "\n" +
                   "Name: " + Name;
        }
    }
}