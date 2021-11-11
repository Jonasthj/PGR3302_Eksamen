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
            GameManager game = new GameManager();
            
            game.CreatePlayers(4);
            Assert.AreEqual(BoardMap.Players[1], 0);
            Assert.AreEqual(BoardMap.Players[2], 0);
            Assert.AreEqual(BoardMap.Players[3], 0);
            Assert.AreEqual(BoardMap.Players[4], 0);
        }
        
        
    }
}