using System;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.PlayerFlyweight.Static;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class Property : ISquare, IProperty
    {
        #region Properties

        private int Id { get;}
        private string Name { get;}
        private ConsoleColor Color { get;}
        public int BuyPrice { get;}
        public int RentPrice { get;}
        public bool IsAvailable { get; private set; }
        public int OwnerId { get; private set; }

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

        public string GetName()
        {
            return Name;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            var price = CheckAvailable(out var owner);

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
                string playerName = PlayerGenerator.GetInstance().Get(OwnerId).Name;
                price = $"Rent: {RentPrice}M";
                owner = $"Owner: {playerName}\n";
            }

            return price;
        }


        public bool SetAvailability(bool status)
        {
            return IsAvailable = status;
        }

        public int SetOwner(int id)
        {
            return OwnerId = id;
        }

        #endregion
    }
}