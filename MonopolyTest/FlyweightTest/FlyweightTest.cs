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
            
            Console.WriteLine(player.ToString());
            StringAssert.Contains(uuid.ToString(), player.ToString());
        }


        [Test]
        public void ShouldRetrievePlayerName()
        {
            Player player = GenerateRandomPlayer();
            player.SetExtrinsicPart("Kjartan", new Wallet(200));
            
            Assert.AreEqual("Kjartan", player.Name);
        }

        [Test]
        public void ShouldRetrievePlayerWallet()
        {
            Player player = GenerateRandomPlayer();
            player.SetExtrinsicPart("Petter", new Wallet(200));
            
            Assert.AreEqual(200, player.Wallet.Balance);
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