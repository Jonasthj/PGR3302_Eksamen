using System;
using System.Drawing;
using System.IO;
using Monopoly.Factory.Classes;
using Monopoly.Factory.Interface;
using NUnit.Framework;

namespace MonopolyTest.FactoryTest
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
            Guid uuid = Guid.NewGuid();
            CreatePrison prison = new CreatePrison(1, uuid.ToString());
            ISquare square = prison.BuildSquare();
            
            StringAssert.Contains(uuid.ToString(), square.ToString());
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
            CreateStart start = new CreateStart(2, uuid.ToString());
            ISquare square = start.BuildSquare();
            
            StringAssert.Contains(uuid.ToString(), square.ToString());
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
                CreatePrison prison = new CreatePrison(1, uuid.ToString());
                square = prison.BuildSquare();
            }

            if (randomNum == 2)
            {
                CreateProperty property = new CreateProperty(5, uuid.ToString(), ConsoleColor.Blue, 123, 123);
                square = property.BuildSquare();
            }

            if (randomNum == 3)
            {
                CreateStart start = new CreateStart(2, uuid.ToString());
                square = start.BuildSquare();
            }

            return square;
        }
        #endregion
    }
}