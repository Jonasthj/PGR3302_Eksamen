using System;
using System.Collections.Generic;
using Monopoly.Flyweight;

namespace Monopoly.Factory.Classes
{
    public class GameManager
    {
        public BoardMap map = new();
        
        
        //Create x players (as defined in menuUI) and put them in start position on boardmap
        public void CreatePlayers(int playersCount)
        {
            for (int i = 1; i < playersCount+1; i++)
            {
                map.Players.Add(i, 0);
                
                PlayerGenerator.Get(i);
            }
        }

        public void SetPlayersInfo(string name, int id)
        {
            Player player = PlayerGenerator.Get(id);
            player.SetExtrinsicPart(name, new Wallet(600), false);
        }
    }
}