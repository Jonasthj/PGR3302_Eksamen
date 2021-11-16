using System;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Prison : ISquare
    {
        #region Properties

        private int Id { get;}
        private string Name { get;}

        #endregion

        #region Constructors
        
        public Prison()
        {
            Id = 6;
            Name = "Prison";
        }

        #endregion

        #region Implemented

        public void PrintSquare()
        {
            Console.WriteLine(ToString());
        }

        public int GetId()
        {
            return Id;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return "-----------------" +
                   "\n" +
                   $" {Name}\n"+
                    " Skip one round :(" +
                   "\n" +
                   "-----------------";
        }

        #endregion
        
    }
}