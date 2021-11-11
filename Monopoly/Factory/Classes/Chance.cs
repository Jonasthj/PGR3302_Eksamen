using System;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Chance : ISquare
    {
        #region Properties
        private int Id { get; }
        private string Name { get; }
        private string Description { get; }
        
        #endregion

        #region Constructor
        
        public Chance(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        
        #endregion

        #region Implemented
        
        public void PrintSquare()
        {
            Console.WriteLine(ToString());
        }
        
        #endregion

        #region ToString
        
        public override string ToString()
        {
            return "Id: " + Id + "\n" +
                   "Name: " + Name + "\n" +
                   "Description: " + Description;
        }
        
        #endregion
    }
}