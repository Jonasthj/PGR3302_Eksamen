using System;
using System.Collections.Generic;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.Objects;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class Chance : ISquare, IChance
    {
        /// <summary>
        /// The chance card class, stores all the properties of a chance card,
        /// as well as a list of all chance cards to allow for picking a random.
        /// </summary>
        
        #region Properties

        public int Id { get; }
        private string Name { get; }
        public List<ChanceCard> ChanceCards { get; }
        private ChanceCard ChanceCard { get; set; }

        #endregion
        
        public Chance(int id, List<ChanceCard> chanceCards)
        {
            Id = id;
            Name = "Chance";
            ChanceCards = chanceCards;
        }
        
        #region Methods
        
        public void PrintSquare()
        {
            Console.WriteLine(ToString());
        }

        public string GetName()
        {
            return Name;
        }
        
        public void SetChanceCard(ChanceCard chanceCard)
        {
            ChanceCard = chanceCard;
        }

        #endregion
        
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            return "-----------------" +
                   "\n" +
                   $" {Name}:\n"+
                   $" {ChanceCard}" +
                   "\n" +
                   "-----------------";
        }
    }
}