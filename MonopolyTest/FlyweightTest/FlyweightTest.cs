using System;
using Monopoly.Flyweight;
using NUnit.Framework;

namespace MonopolyTest.FlyweightTest
{
    public class FlyweightTest
    {

        [Test]
        public void ShouldRetrievePlayerInfo()
        {
            Guid uuid = Guid.NewGuid();
            Player player = GenerateRandomPlayer();
            player.SetExtrinsicPart(uuid.ToString() ,new Wallet(500));

            StringAssert.Contains(uuid.ToString(), player.ToString());
        }

        private Player GenerateRandomPlayer()
        {
            PlayerGenerator playerGenerator = new();
            Random random = new();
            int randomNum = random.Next(1, 4);
            Player player = playerGenerator.Get(randomNum);
            return player;
        }
    }
}