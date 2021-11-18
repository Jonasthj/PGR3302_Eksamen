using System;
using Monopoly;
using Monopoly.Logics;
using Monopoly.Logics.PlayerFlyweight;
using Monopoly.Logics.PlayerFlyweight.Abstract;
using Monopoly.Logics.PlayerFlyweight.Static;
using NUnit.Framework;

namespace MonopolyTest.FlyweightTest
{
    public class WalletCalculatorTest
    {
        #region Fields

        private readonly WalletCalculator _walletCalculator = new WalletCalculator();
        private PlayerGenerator _generator = PlayerGenerator.GetInstance();
        
        #endregion

        #region Tests

        [Test]
        public void ShouldReturnPlayerBalance()
        {
            Player player = _generator.Get(1);
            player.SetExtrinsicPart("Test", new Wallet(500), false);
            
            Assert.AreEqual(500, _walletCalculator.CheckBalance(1));
        }

        [Test]
        public void ShouldAddMoneyToWallet()
        {
            Player player = _generator.Get(1);
            player.SetExtrinsicPart("Test", new Wallet(500), false);
            
            _walletCalculator.AddBalance(1, 200);
            
            Assert.AreEqual(700, _walletCalculator.CheckBalance(1));
        }

        [Test]
        public void ShouldSubtractMoneyFromWallet()
        {
            Player player = _generator.Get(1);
            player.SetExtrinsicPart("Test", new Wallet(500), false);
            
            _walletCalculator.SubtractBalance(1, 200);
            
            Assert.AreEqual(300, _walletCalculator.CheckBalance(1));
        }

        #endregion
        

    }
}