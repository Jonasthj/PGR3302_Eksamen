using System;
using System.IO;
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
            Guid uuid = Guid.NewGuid();
            CreateChance chance = new CreateChance(1,"Chance", uuid.ToString());
            ISquare square = chance.BuildSquare();
            
            StringAssert.Contains(uuid.ToString(),square.ToString());
        }

       [Test]
        public void ShouldReturnPrisonString()
        {
            Guid uuid = Guid.NewGuid();
            CreatePrison prison = new CreatePrison(1, uuid.ToString());
            ISquare square = prison.BuildSquare();
            
            StringAssert.Contains(uuid.ToString(), square.ToString());
        }
        


        /*[Test]
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
        public void ShouldReadRandomSquareString()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ISquare square = GenerateRandomSquare();
                square.PrintSquare();
                string consoleOutput = stringWriter.ToString();
                
                Assert.AreEqual(consoleOutput, square.ToString() + "\r\n");
            }
        }
        
        private static ISquare GenerateRandomSquare()
        {
            Random random= new Random();
            int randomNum=random.Next(3);

            if(randomNum==0)
                return new Chance();
            if(randomNum==1)
                return new Prison();
            if(randomNum==2)
                return new Property();
            
            return new Start();
        }*/
    }
}