using System.Collections.Generic;
using Monopoly.Database;
using Monopoly.Factory.Classes;
using Monopoly.Factory.Interface;
using Monopoly.Flyweight;
using Monopoly.Logics.PlayerFlyweight.Static;

namespace Monopoly.Logics
{
    public class GameManager
    {
        public BoardMap Map;
        private readonly PlayerGenerator _generator = PlayerGenerator.GetInstance();
        
        public BoardMap CreateBoardMap()
        {
            Map = new BoardMap();
            
            var jsonData = JsonFileReader.GetJsonData();
            
            PropertyJson propertyJson = new(jsonData);
            ChanceJson chanceJson = new(jsonData);
            
            Prison prison = new Prison();
            Start start = new Start();
            List<ISquare> chances = chanceJson.RetrieveAll();

            // Create Property Squares
            for (int i = 0; i < 20; i++)
            {
                Map.MapSquares[i] = propertyJson.Retrieve(i);
            }
            // Create Chance Squares
            foreach (var chance in chances)
            {
                Map.MapSquares[chance.GetId()] = chance;
            }
            
            // Create Start and Prison square.
            Map.MapSquares[start.GetId()] = start;
            Map.MapSquares[prison.GetId()] = prison;

            return Map;
        }
        
        
        //Create x players (as defined in menuUI) and put them in start position on boardmap
        public void CreatePlayers(int playersCount)
        {
            for (int i = 1; i < playersCount+1; i++)
            {
                Map.Players.Add(i, 0);
                _generator.Get(i);
                // PlayerGenerator.Get(i);
            }
        }

        public void SetPlayersInfo(string name, int id)
        {
            Player player = _generator.Get(id);
            player.SetExtrinsicPart(name, new Wallet(600), false);
        }
    }
}