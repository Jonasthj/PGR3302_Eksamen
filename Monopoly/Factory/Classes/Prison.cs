using System;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Prison : ISquare
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Prison(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void PrintSquare()
        {
            Console.WriteLine(ToString());
        }
        
        public override string ToString()
        {
            return "Id: " + Id + "\n" +
                   "Name: " + Name;
        }
    }
}