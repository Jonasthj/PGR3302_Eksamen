using System;
using System.Collections.Generic;
using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class Chance : ISquare, IChance
    {
        #region Properties

        private int Id { get; }
        private string Name { get; }
        private List<ChanceCard> ChanceCards { get; }
        
        private ChanceCard ChanceCard { get; set; }

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

        #endregion

        #region ToString

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