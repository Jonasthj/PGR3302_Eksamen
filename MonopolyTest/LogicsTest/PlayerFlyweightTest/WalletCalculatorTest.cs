using Monopoly.Logics;
using Monopoly.Logics.Objects;
using Monopoly.Logics.PlayerFlyweight;
using Monopoly.Logics.PlayerFlyweight.Abstract;
using Monopoly.Logics.PlayerFlyweight.Singleton;
using NUnit.Framework;

namespace MonopolyTest.LogicsTest.PlayerFlyweightTest
{
    public class WalletCalculatorTest
    {
        private readonly WalletCalculator _walletCalculator = new WalletCalculator();
        private readonly PlayerGenerator _generator = PlayerGenerator.GetInstance();
        
        #region Tests

        [Test]
        public void ShouldCheckWalletBalance()
        {
            Player player = _generator.Get(1);
            player.SetExtrinsicPart("Test", new Wallet(500), false);
            
            Assert.AreEqual(500, player.Wallet.Balance);
        }

        [Test]
        public void ShouldAddMoneyToWallet()
        {
            Player player = _generator.Get(1);
            player.SetExtrinsicPart("Test", new Wallet(500), false);
            
            _walletCalculator.AddBalance(1, 200);
            
            Assert.AreEqual(700, player.Wallet.Balance);
        }

        [Test]
        public void ShouldSubtractMoneyFromWallet()
        {
            Player player = _generator.Get(1);
            player.SetExtrinsicPart("Test", new Wallet(500), false);
            
            _walletCalculator.SubtractBalance(1, 200);
            
            Assert.AreEqual(300, player.Wallet.Balance);
        }

        #endregion
    }
}