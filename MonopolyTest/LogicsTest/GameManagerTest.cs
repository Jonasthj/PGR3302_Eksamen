using Monopoly;
using Monopoly.Factory.Classes;
using Monopoly.Logics;
using NUnit.Framework;

namespace MonopolyTest
{
    public class GameManagerTest
    {
        
        /*[Test]
        public void ShouldAddPlayersToBoardMapAndToStartPosition()
        {
            GameManager manager = GameManager.GetInstance();
            manager.CreatePlayers(4);
            
            Assert.AreEqual(manager.Map.Players[1], 0);
            Assert.AreEqual(manager.Map.Players[2], 0);
            Assert.AreEqual(manager.Map.Players[3], 0);
            Assert.AreEqual(manager.Map.Players[4], 0);
        }*/

        [Test]
        public void ShouldAddPlayersAndDeleteOne()
        {
            // GameManager game = new GameManager();
            //
            // //Creating players object on boardmap
            // int count = Convert.ToInt32(Console.ReadLine());
            // game.CreatePlayers(count);
            //
            // //Setting players values 
            // for (int i = 1; i < count+1; i++)
            // {
            //     string name = Console.ReadLine();
            //     game.FillPlayersInfo(name, i);
            // }
            // foreach (KeyValuePair<int, Player> player in PlayerGenerator.Players)
            // {
            //     Console.WriteLine("Key: {0}, {1}", 
            //         player.Key, player.Value);
            // }
            //
            // PlayerGenerator.Delete(1);
            //
            // foreach (KeyValuePair<int, Player> player in PlayerGenerator.Players)
            // {
            //     Console.WriteLine("Key: {0}, {1}", 
            //         player.Key, player.Value);
            // }
        }
        
        
    }
}