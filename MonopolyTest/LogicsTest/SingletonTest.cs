using Monopoly.Flyweight;
using Monopoly.Logics.PlayerFlyweight.Abstract;
using Monopoly.Logics.PlayerFlyweight.Static;
using NUnit.Framework;

namespace MonopolyTest.LogicsTest
{
    public class SingletonTest
    {
        [Test]
        public void ShouldGetSameInstanceOfPlayerGenerator()
        {
            PlayerGenerator a = PlayerGenerator.GetInstance();
            PlayerGenerator b = PlayerGenerator.GetInstance();

            Player player1 = a.Get(1);
            player1.SetExtrinsicPart("Petter", new Wallet(100), false);
            
            Assert.AreEqual(a, b);
            Assert.AreEqual(a.Get(1), b.Get(1));
        }
    }
}