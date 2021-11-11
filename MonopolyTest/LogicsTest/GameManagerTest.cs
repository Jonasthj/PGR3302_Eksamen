using Monopoly;
using Monopoly.Factory.Classes;
using NUnit.Framework;

namespace MonopolyTest
{
    public class GameManagerTest
    {
        
        [Test]
        public void ShouldAddPlayersToBoardMapAndToStartPosition()
        {
            GameManager manager = new GameManager();
            
            manager.CreatePlayers(4);
            Assert.AreEqual(manager.map.Players[1], 0);
            Assert.AreEqual(manager.map.Players[2], 0);
            Assert.AreEqual(manager.map.Players[3], 0);
            Assert.AreEqual(manager.map.Players[4], 0);
        }
        
        
    }
}