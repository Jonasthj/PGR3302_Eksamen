﻿using System;
using System.Drawing;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Property : ISquare
    {
        private int Id { get;}
        private string Name { get;}
        private Color Color { get;}
        private int BuyPrice { get;}
        private int RentPrice { get;}
        public bool IsAvailable { get; set; }
        public int OwnerId { get; set; }

        public Property(int id, string name, Color color, int buyPrice, int rentPrice)
        {
            Id = id;
            Name = name;
            Color = color;
            BuyPrice = buyPrice;
            RentPrice = rentPrice;
            // Property is always available at the beginning of the game.
            IsAvailable = true;
        }
        
        public void PrintSquare()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return "Id: " + Id + "\n" +
                   "Name: " + Name + "\n" +
                   Color + "\n" +
                   "IsAvailable: " + IsAvailable + "\n" +
                   "BuyPrice: " + BuyPrice + "\n" +
                   "RentPrice: " + RentPrice + "\n" +
                   "OwnerId: " + OwnerId + "\n";
        }
    }
}