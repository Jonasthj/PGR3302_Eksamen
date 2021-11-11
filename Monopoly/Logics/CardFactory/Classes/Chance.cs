using System;
using System.Collections;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Chance : ISquare
    {
        #region Properties
        private int Id { get; }
        private string Name { get; }
        private ArrayList ChanceCards { get; }

        public Chance(int id, ArrayList chanceCards)
        {
            Id = id;
            Name = "Chance";
            ChanceCards = chanceCards;
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
            string cards = "";
                
            foreach (var chance in ChanceCards)
            {
                cards += "    " + chance + "\n";
            }
            
            
            return "Id: " + Id + "\n" +
                   "Name: " + Name + "\n" +
                   "ChanceCards: \n" + cards;
        }
        
        #endregion
    }
}