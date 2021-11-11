using System;
using Monopoly;
using Monopoly.Flyweight;
using NUnit.Framework;

namespace MonopolyTest.FlyweightTest
{
    public class WalletCalculatorTest
    {
        #region Fields

        private readonly WalletCalculator _walletCalculator = new WalletCalculator();
        
        #endregion

        #region Tests

        [Test]
        public void ShouldReturnPlayerBalance()
        {
            Player player = PlayerGenerator.Get(1);
            player.SetExtrinsicPart("Test", new Wallet(500), false);
            
            Assert.AreEqual(500, _walletCalculator.CheckBalance(1));
        }

        [Test]
        public void ShouldAddMoneyToWallet()
        {
            Player player = PlayerGenerator.Get(1);
            player.SetExtrinsicPart("Test", new Wallet(500), false);
            
            _walletCalculator.AddBalance(1, 200);
            
            Assert.AreEqual(700, _walletCalculator.CheckBalance(1));
        }

        [Test]
        public void ShouldSubtractMoneyFromWallet()
        {
            Player player = PlayerGenerator.Get(1);
            player.SetExtrinsicPart("Test", new Wallet(500), false);
            
            _walletCalculator.SubtractBalance(1, 200);
            
            Assert.AreEqual(300, _walletCalculator.CheckBalance(1));
        }

        #endregion
        

    }
}