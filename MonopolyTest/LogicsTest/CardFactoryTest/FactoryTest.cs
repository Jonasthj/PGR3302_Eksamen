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
        public void ShouldReturnChanceString()
        {
            Guid uuid = Guid.NewGuid();
            CreateChance chance = new CreateChance(1,null);
            ISquare square = chance.BuildSquare();
            
            StringAssert.Contains(uuid.ToString(),square.ToString());
        }

       [Test]
        public void ShouldReturnPrisonString()
        {
            CreatePrison prison = new CreatePrison();
            ISquare square = prison.BuildSquare();

            Assert.AreEqual(6, square.GetId());
            Assert.AreEqual("Prison", square.GetName());
        }
        
        [Test]
        public void ShouldReturnPropertyString()
        {
            Guid uuid = Guid.NewGuid();
            CreateProperty property = new CreateProperty(5, uuid.ToString(), ConsoleColor.Blue, 123, 123);
            ISquare square = property.BuildSquare();
            
            StringAssert.Contains(uuid.ToString(), square.ToString());
        }

        [Test]
        public void ShouldReturnStartString()
        {
            Guid uuid = Guid.NewGuid();
            CreateStart start = new CreateStart();
            ISquare square = start.BuildSquare();
            
            Assert.AreEqual(0, square.GetId());
            Assert.AreEqual("Start", square.GetName());
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
        #endregion

        #region HelperMethods
        
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
        #endregion
    }
}