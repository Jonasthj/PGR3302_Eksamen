using Monopoly.Factory.Classes;
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
            chance.Description = "Move three steps back :(";
            StringAssert.Contains(chance.Name, chance.ToString());
            StringAssert.Contains(chance.Description, chance.ToString());
        }

        [Test]
        public void ShouldReturnPrisonString()
        {
            Prison prison = new();
            prison.Id = 2;
            prison.Name = "Ila fengsel";
            StringAssert.Contains(prison.Name, prison.ToString());
        }
        
        
    }
}