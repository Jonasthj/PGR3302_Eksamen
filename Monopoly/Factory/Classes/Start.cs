using System;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Start : ISquare
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        
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