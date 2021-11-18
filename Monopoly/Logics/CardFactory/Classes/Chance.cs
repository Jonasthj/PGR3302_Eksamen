using System;
using System.Collections.Generic;
using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class Chance : ISquare, IChance
    {
        /// <summary>
        /// The chance card class, stores all the properties of a chance card,
        /// as well as a list of all chance cards to allow for picking a random.
        /// </summary>
        
        #region Properties

        private int Id { get; }
        private string Name { get; }
        private List<ChanceCard> ChanceCards { get; }
        private ChanceCard ChanceCard { get; set; }

        #endregion
        
        #region Methods
        public Chance(int id, List<ChanceCard> chanceCards)
        {
            Id = id;
            Name = "Chance";
            ChanceCards = chanceCards;
        }
        
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

        public List<ChanceCard> GetChanceCards()
        {
            return ChanceCards;
        }

        public void SetChanceCard(ChanceCard chanceCard)
        {
            ChanceCard = chanceCard;
        }

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

        #endregion
    }
}