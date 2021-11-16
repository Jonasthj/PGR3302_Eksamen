using System;
using System.Collections.Generic;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Chance : ISquare
    {
        #region Properties

        private int Id { get; }
        private string Name { get; }
        private List<ChanceCard> ChanceCards { get; }

        public Chance(int id, List<ChanceCard> chanceCards)
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

        public int GetId()
        {
            return Id;
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