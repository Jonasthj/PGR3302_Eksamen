using System;
using Monopoly.Logics.PlayerFlyweight;
using Monopoly.Logics.PlayerFlyweight.Abstract;
using Monopoly.Logics.PlayerFlyweight.Static;
using NUnit.Framework;

namespace MonopolyTest.LogicsTest.PlayerFlyweightTest
{
    public class FlyweightTest
    {

        [Test]
        public void ShouldRetrievePlayerInfo()
        {
            Guid uuid = Guid.NewGuid();
            Player player = GenerateRandomPlayer();
            player.SetExtrinsicPart(uuid.ToString(), new Wallet(500), true);

            StringAssert.Contains(uuid.ToString(), player.Name);
            Assert.AreEqual(500, player.Wallet.Balance);
            Assert.AreEqual(true, player.InPrison);
        }

        private Player GenerateRandomPlayer()
        {
            PlayerGenerator generator = PlayerGenerator.GetInstance();
            Random random = new();
            int randomNum = random.Next(1, 4);
            Player player = generator.Get(randomNum);
            return player;
        }
    }
}