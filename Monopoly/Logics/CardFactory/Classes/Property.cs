using System;
using System.Drawing;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Property : ISquare
    {
        #region Properties

        private int Id { get;}
        private string Name { get;}
        private ConsoleColor Color { get;}
        private int BuyPrice { get;}
        private int RentPrice { get;}
        public bool IsAvailable { get; set; }
        public int OwnerId { get; set; }

        #endregion

        #region Constructors

        public Property(int id, string name, ConsoleColor color, int buyPrice, int rentPrice)
        {
            Id = id;
            Name = name;
            Color = color;
            BuyPrice = buyPrice;
            RentPrice = rentPrice;
            // Property is always available at the beginning of the game.
            IsAvailable = true;
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
            var price = CheckAvailable(out var owner);

            // Console.ForegroundColor;
            Console.ForegroundColor = Color;
            
            return "-----------------" +
                   "\n" +
                   $" {Name}\n"+
                   $" {owner}" +
                   $" {price}" +
                   "\n" +
                   "-----------------";
        }

        private string CheckAvailable(out string owner)
        {
            string price;
            owner = "";

            if (IsAvailable)
            {
                price = $"Buy: {BuyPrice}M";
            }
            else
            {
                price = $"Rent: {RentPrice}M";
                owner = $"Owner: Player {OwnerId}\n";
            }

            return price;
        }

        #endregion
        
    }
}