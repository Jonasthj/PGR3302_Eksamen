using Monopoly.Logics;
using Monopoly.Logics.PlayerFlyweight.Abstract;
using Monopoly.Logics.PlayerFlyweight.Static;
using NUnit.Framework;

namespace MonopolyTest.LogicsTest
{
    public class GameManagerTest
    {
        private readonly GameManager _manager = GameManager.GetInstance();

        [SetUp]
        public void Init()
        {
            _manager.InitializeMap();
        }

        [Test]
        public void ShouldAddPlayersToBoardMapAndToStartPosition()
        {
            _manager.CreatePlayers(4);
            
            Assert.AreEqual(_manager.Map.Players[1], 0);
            Assert.AreEqual(_manager.Map.Players[2], 0);
            Assert.AreEqual(_manager.Map.Players[3], 0);
            Assert.AreEqual(_manager.Map.Players[4], 0);
        }

        [Test]
        public void ShouldBlackListPlayer()
        {
            _manager.CreatePlayers(4);
            
            PlayerGenerator generator = PlayerGenerator.GetInstance();
            generator.Blacklist(1);

            Player player = _manager.Generator.Get(1);

            foreach (var blackListed in _manager.Generator.BlackListed)
            {
                Assert.AreEqual(blackListed, player);
                break;
            }
        }
    }
}