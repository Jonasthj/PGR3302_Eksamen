using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Monopoly.Database;
using Monopoly.Factory.Interface;
using Monopoly.Flyweight;
using Monopoly.UI;

namespace Monopoly.Factory.Classes
{
    public class GameManager
    {
        public BoardMap map;
        
        public BoardMap CreateBoardMap()
        {
            map = new BoardMap();

            PropertyJson propertyJson = new(JsonFileReader.GetJsonData());
            ChanceJson chanceJson = new(JsonFileReader.GetJsonData());
            
            Prison prison = new Prison();
            Start start = new Start();
            List<ISquare> chances = chanceJson.RetrieveAll();

            // Create Property Squares
            for (int i = 0; i < 20; i++)
            {
                map.MapSquares[i] = propertyJson.Retrieve(i);
            }
            // Create Chance Squares
            foreach (var chance in chances)
            {
                map.MapSquares[chance.GetId()] = chance;
            }
            
            // Create Start and Prison square.
            map.MapSquares[start.GetId()] = start;
            map.MapSquares[prison.GetId()] = prison;

            return map;
        }
        
        
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