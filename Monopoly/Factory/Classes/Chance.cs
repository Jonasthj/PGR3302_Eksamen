using System;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Chance : ISquare
    {
        private int Id { get; }
        private string Name { get; }
        private string Description { get; }

        public Chance(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        
        public void PrintSquare()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return "Id: " + Id + "\n" +
                   "Name: " + Name + "\n" +
                   "Description: " + Description;
        }
    }
}