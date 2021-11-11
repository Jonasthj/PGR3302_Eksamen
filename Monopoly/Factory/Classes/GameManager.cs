using System;
using System.Collections.Generic;

namespace Monopoly.Factory.Classes
{
    public class GameManager
    {
        BoardMap boardMap = new BoardMap();
        
        //Create x players (as defined in menuUI) and put them in start position on boardmap
        public void CreatePlayers(int playersCount)
        {
            for (int i = 1; i < playersCount+1; i++)
            {
                boardMap.Players.Add(i, 0); 
            }
            
            foreach (KeyValuePair<int, int> player in boardMap.Players)
            {
                Console.WriteLine("Key: {0}, Value: {1}", 
                    player.Key, player.Value);
            }
        }
    }
}