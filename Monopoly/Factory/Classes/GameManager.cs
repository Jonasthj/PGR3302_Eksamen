using System;
using System.Collections.Generic;
using Monopoly.Flyweight;

namespace Monopoly.Factory.Classes
{
    public class GameManager
    {
        //Create x players (as defined in menuUI) and put them in start position on boardmap
        public void CreatePlayers(int playersCount)
        {
            for (int i = 1; i < playersCount+1; i++)
            {
                BoardMap.Players.Add(i, 0);
                
            }

            foreach (KeyValuePair<int, int> player in BoardMap.Players)
            {
                Console.WriteLine("Key: {0}, Index: {1}", 
                    player.Key, player.Value);
            }
        }

        public void FillPlayersInfo(string name, int id)
        {
            Player player = PlayerGenerator.Get(id);
            player.SetExtrinsicPart(name, new Wallet(600), false);
        }
    }
}