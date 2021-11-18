using System;
using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class Start : ISquare
    {
        #region Properties

        public int Id { get;}
        private string Name { get;}

        #endregion

        #region Methods

        public Start()
        {
            Id = 0;
            Name = "Start";
        }
        
        public void PrintSquare()
        {
            Console.WriteLine(ToString());
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
                    " Receive 100M" +
                   "\n" +
                   "-----------------";
        }

        #endregion
    }
}