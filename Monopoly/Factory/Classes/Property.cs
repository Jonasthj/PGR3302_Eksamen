using System;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Property : ISquare
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool IsAvailable { get; set; }
        public int BuyPrice { get; set; }
        public int RentPrice { get; set; }
        public int OwnerId { get; set; }

        public void PrintSquare()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return "Id: " + Id + "\n" +
                   "Name: " + Name + "\n" +
                   "Color: " + Color + "\n" +
                   "IsAvailable: " + IsAvailable + "\n" +
                   "BuyPrice: " + BuyPrice + "\n" +
                   "RentPrice: " + RentPrice + "\n" +
                   "OwnerId: " + OwnerId + "\n";
        }
    }
}