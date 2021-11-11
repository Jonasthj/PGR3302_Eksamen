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
            player.SetExtrinsicPart(uuid.ToString() ,new Wallet(500), false);
            
            Console.WriteLine(player.ToString());
            StringAssert.Contains(uuid.ToString(), player.ToString());
        }


        [Test]
        public void ShouldRetrievePlayerName()
        {
            Player player = GenerateRandomPlayer();
            player.SetExtrinsicPart("Kjartan", new Wallet(200), false);
            
            Assert.AreEqual("Kjartan", player.Name);
        }

        [Test]
        public void ShouldRetrievePlayerWallet()
        {
            Player player = GenerateRandomPlayer();
            player.SetExtrinsicPart("Petter", new Wallet(200), false);
            
            Assert.AreEqual(200, player.Wallet.Balance);
        }

        [Test]
        public void ShouldRetrievePlayerPrisonStatus()
        {
            Player player = GenerateRandomPlayer();
            player.SetExtrinsicPart("Kjartan", new Wallet(0), true);
            Assert.AreEqual(true, player.InPrison);
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