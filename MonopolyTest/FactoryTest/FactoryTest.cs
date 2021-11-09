using Monopoly.Factory.Classes;
using NUnit.Framework;

namespace MonopolyTest.FactoryTest
{
    public class FactoryTest
    {
        [Test]
        public void PrisonShouldReturnToString()
        {
            Prison prison = new();
            prison.setId(5);
            prison.setName("Ila Fengsel");
            //TODO: Assert.Equals(prison.ToString(), prison.PrintSquare());
        }
    }
}