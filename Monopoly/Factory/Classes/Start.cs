using System;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Start : ISquare
    {
        private int Id { get;}
        private string Name { get;}

        public Start()
        {
            Id = 0;
            Name = "Start";
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