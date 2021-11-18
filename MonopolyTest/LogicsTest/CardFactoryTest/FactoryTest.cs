using System;
using System.IO;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;
using NUnit.Framework;

namespace MonopolyTest.LogicsTest.CardFactoryTest
{
    public class FactoryTest
    {
        #region Tests
        
        [Test]
        public void ShouldReturnChanceProperties()
        {
            CreateChance chance = new CreateChance(53,null);
            ISquare square = chance.BuildSquare();

            Assert.AreEqual(53, square.GetId());
        }

       [Test]
        public void ShouldReturnPrisonProperties()
        {
            CreatePrison prison = new CreatePrison();
            ISquare square = prison.BuildSquare();
            
            // Expected = Default Values
            Assert.AreEqual(6, square.GetId());
            Assert.AreEqual("Prison", square.GetName());
        }
        
        [Test]
        public void ShouldReturnPropertyProperties()
        {
            Guid uuid = Guid.NewGuid();
            CreateProperty property = new CreateProperty(5, uuid.ToString(), ConsoleColor.Blue, 123, 123);
            ISquare square = property.BuildSquare();
            
            StringAssert.Contains(uuid.ToString(), square.ToString());
        }

        [Test]
        public void ShouldReturnStartProperties()
        {
            CreateStart start = new CreateStart();
            ISquare square = start.BuildSquare();
            
            // Expected = Default values
            Assert.AreEqual(0, square.GetId());
            Assert.AreEqual("Start", square.GetName());
        }

        [Test]
        public void ShouldReadRandomSquareString()
        {
            using StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            ISquare square = GenerateRandomSquare();
            square.PrintSquare();
            string consoleOutput = stringWriter.ToString();
            
            // If testing on Mac / terminal: remove "\r".
            Assert.AreEqual(consoleOutput, square + "\r\n");
        }
        
        #endregion

        private static ISquare GenerateRandomSquare()
        {
            Random random= new Random();
            int randomNum=random.Next(3);
            Guid uuid = Guid.NewGuid();
            
            // Must be initialized.
            ISquare square = null;

            if (randomNum == 0)
            {
                CreateChance chance = new CreateChance(1,null);
                square = chance.BuildSquare();
            }

            if (randomNum == 1)
            {
                CreatePrison prison = new CreatePrison();
                square = prison.BuildSquare();
            }

            if (randomNum == 2)
            {
                CreateProperty property = new CreateProperty(5, uuid.ToString(), ConsoleColor.Blue, 123, 123);
                square = property.BuildSquare();
            }

            if (randomNum == 3)
            {
                CreateStart start = new CreateStart();
                square = start.BuildSquare();
            }

            return square;
        }
    }
}