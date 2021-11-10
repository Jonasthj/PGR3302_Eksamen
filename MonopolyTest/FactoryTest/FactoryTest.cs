using System;
using Monopoly.Factory.Classes;
using Monopoly.Factory.Interface;
using NUnit.Framework;

namespace MonopolyTest.FactoryTest
{
    public class FactoryTest
    {
        [Test]
        public void ShouldReturnChanceString()
        {
            Chance chance = new();
            chance.Id = 2;
            chance.Name = "Chance";
            chance.Description = "Move two steps forward";
            
            Assert.AreEqual("Id: " + chance.Id + "\n" +
                          "Name: " + chance.Name + "\n" +
                          "Description: " + chance.Description, chance.ToString());
        }

        [Test]
        public void ShouldReturnPrisonString()
        {
            Prison prison = new();
            prison.Id = 2;
            prison.Name = "Prison";
            Assert.AreEqual("Id: " + prison.Id + "\n" +
                                   "Name: " + prison.Name, prison.ToString());
        }


        [Test]
        public void ShouldReturnPropertyString()
        {
            
            Property property = new();
            property.Id = 30;
            property.Name = "Ullevål Sykehus";
            property.Color = "Blue";
            property.IsAvailable = true;
            property.BuyPrice = 123;
            property.RentPrice = 33;
            property.OwnerId = 2;
            
            Assert.AreEqual("Id: " + property.Id + "\n" +
                            "Name: " + property.Name + "\n" +
                            "Color: " + property.Color + "\n" +
                            "IsAvailable: " + property.IsAvailable + "\n" +
                            "BuyPrice: " + property.BuyPrice + "\n" +
                            "RentPrice: " + property.RentPrice + "\n" +
                            "OwnerId: " + property.OwnerId + "\n", property.ToString());
        }

        [Test]
        public void ShouldReturnStartString()
        {
            Start start = new();
            start.Id = 1;
            start.Name = "Start";
            
            Assert.AreEqual("Id: " + start.Id + "\n" +
                            "Name: " + start.Name, start.ToString());
        }

        
        [Test]
        public void GenerateSomething()
        {
            ISquare squareMaker = new Prison();
            squareMaker.PrintSquare();
            string squareOutput = Console.ReadLine();
            Console.WriteLine(squareOutput);

        }

        
        
        public static ISquare GenerateRandomSquare()
        {
            Random random= new Random();
            int randomNum=random.Next(4);

            if(randomNum==0)
                return new Chance();
            else if(randomNum==1)
                return new Prison();
            else if(randomNum==2)
                return new Property();
            else
                return new Start();
        }

        
        
    }
}