using System;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.PlayerFlyweight.Singleton;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class Property : ISquare, IProperty
    {
        #region Properties

        private int _id;
        private string Name { get;}
        private ConsoleColor Color { get;}
        public int BuyPrice { get; private set; }
        public int RentPrice { get; private set; }
        public bool IsAvailable { get; private set; }
        public int OwnerId { get; private set; }

        #endregion

        #region Methods

        public Property(int id, string name, ConsoleColor color, int buyPrice, int rentPrice)
        {
            _id = id;
            Name = name;
            Color = color;
            BuyPrice = buyPrice;
            RentPrice = rentPrice;
            IsAvailable = true;
        }

        public void PrintSquare()
        {
            Console.WriteLine(ToString());
        }

        private string CheckAvailable(out string owner)
        {
            string price;
            owner = "";

            if (IsAvailable)
                price = $"Buy: {BuyPrice}M";
            else
            {
                string playerName = PlayerGenerator.GetInstance().Get(OwnerId).Name;
                price = $"Rent: {RentPrice}M";
                owner = $"Owner: {playerName}\n";
            }

            return price;
        }
        
        public virtual void SetAvailability(bool status)
        {
            IsAvailable = status;
        }

        public virtual void SetOwner(int id)
        {
            OwnerId = id;
        }

        public virtual void SetBuyPrice(int value)
        {
            BuyPrice = value;
        }
        
        public virtual void SetRentPrice(int value)
        {
            RentPrice = value;
        }
        
        public string GetName()
        {
            return Name;
        }
        
        #endregion
        
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
    }
}