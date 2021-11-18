using System;
using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class Prison : ISquare
    {
        private int Id { get;}
        private string Name { get;}

        public Prison()
        {
            Id = 6;
            Name = "Prison";
        }

        #region Implemented

        public void PrintSquare()
        {
            Console.WriteLine(ToString());
        }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

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