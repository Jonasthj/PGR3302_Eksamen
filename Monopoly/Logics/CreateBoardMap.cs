using System;
using System.Collections.Generic;
using Monopoly.Database;
using Monopoly.Factory.Classes;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.SquareLogics;
using Monopoly.UI;

namespace Monopoly.Logics
{
    public class CreateBoardMap
    {
        private Dictionary<string, AbstractLogics> _controllers = new();

        public BoardMap Create()
        {
            BoardMap map = new BoardMap();
            
            var jsonData = JsonFileReader.GetJsonData();
            
            PropertyJson propertyJson = new(jsonData);
            ChanceJson chanceJson = new(jsonData);
            
            Prison prison = new Prison();
            Start start = new Start();
            List<ISquare> chances = chanceJson.RetrieveAll();

            // Create Property Squares
            for (int i = 0; i < 20; i++)
            {
                map.MapSquares[i] = propertyJson.Retrieve(i);
                if (map.MapSquares[i] != null)
                {
                    AddController(map.MapSquares[i].GetName(), new PropertyLogics());
                }
                
            }
            // Create Chance Squares
            foreach (var chance in chances)
            {
                map.MapSquares[chance.GetId()] = chance;
                
                AddController(chance.GetName(), new ChanceLogics());
            }
            
            // Create Start and Prison square.
            map.MapSquares[start.GetId()] = start;
            map.MapSquares[prison.GetId()] = prison;
            
            AddController(start.GetName(), new StartLogics());
            AddController(prison.GetName(), new PrisonLogics());

            return map;
        }

        public Dictionary<string, AbstractLogics> GetControllers()
        {
            return _controllers;
        }

        private void AddController(string name, AbstractLogics logics)
        {
            _controllers.TryAdd(name, logics);
        }
    }
}