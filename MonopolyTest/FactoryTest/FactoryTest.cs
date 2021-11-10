using System;
using Monopoly.Factory.Classes;
using NUnit.Framework;

namespace MonopolyTest.FactoryTest
{
    public class FactoryTest
    {
        [Test]
        public void ShouldReturnChanceString()
        {
            Guid uuid = Guid.NewGuid();
            Chance chance = new();
            chance.Name = uuid.ToString();
            StringAssert.Contains(chance.Name, chance.ToString());
        }

        [Test]
        public void ShouldReturnPrisonString()
        {
            Guid uuid = Guid.NewGuid();
            Prison prison = new();
            prison.Name = uuid.ToString();
            StringAssert.Contains(prison.Name, prison.ToString());
        }

        
        [Test]
        public void ShouldReturnPropertyString()
        {
            Guid uuid = Guid.NewGuid();
            Property property = new();
            property.Name = uuid.ToString();
            StringAssert.Contains(property.Name , prison.ToString());
        }  
    }
}