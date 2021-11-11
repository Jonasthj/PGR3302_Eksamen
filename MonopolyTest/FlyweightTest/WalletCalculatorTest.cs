using System;
using Monopoly;
using Monopoly.Flyweight;
using NUnit.Framework;

namespace MonopolyTest.FlyweightTest
{
    public class WalletCalculatorTest
    {
        [Test]
        public void ShouldReturnPlayerBalance()
        {
            Player player = PlayerGenerator.Get(1);
            player.SetExtrinsicPart("Test", new Wallet(500), false);
            WalletCalculator walletCalculator = new WalletCalculator();
            Assert.AreEqual(500, walletCalculator.CheckBalance(1));
        }

    }
}