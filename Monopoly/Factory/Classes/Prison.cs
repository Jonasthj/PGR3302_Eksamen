using System;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Prison : ISquare
    {
        private int Id { get;}
        private string Name { get;}

        public Prison()
        {
            Id = 8;
            Name = "Prison";
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