using System.Collections.Generic;
using Monopoly.Database;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.SquareLogics;
using Monopoly.UI;

namespace Monopoly.Logics
{
    public class CreateBoardMap
    {
        private readonly Dictionary<string, AbstractLogics> _controllers = new();

        #region Methods
        
        /// <description>
        /// Filling in information in the squares from the .Json file.
        /// </description>
        public BoardMap Create()
        {
            BoardMap map = new();
            
            var jsonData = JsonFileReader.GetJsonData();
            
            PropertyJson propertyJson = new(jsonData);
            ChanceJson chanceJson = new(jsonData);
            
            Prison prison = new Prison();
            Start start = new Start();
            List<ISquare> chances = chanceJson.RetrieveAll();
            
            AddPropertySquares(map, propertyJson);
            AddChanceSquares(chances, map);
            AddStartSquare(map, start);
            AddPrisonSquare(map, prison);

            return map;
        }

        private void AddPrisonSquare(BoardMap map, Prison prison)
        {
            map.MapSquares[prison.Id] = prison;
            AddController(prison.GetName(), new PrisonLogics());
        }

        private void AddStartSquare(BoardMap map, Start start)
        {
            map.MapSquares[start.Id] = start;
            AddController(start.GetName(), new StartUI());
        }

        private void AddChanceSquares(List<ISquare> chances, BoardMap map)
        {
            foreach (var square in chances)
            {
                Chance chance = (Chance) square;
                map.MapSquares[chance.Id] = chance;

                AddController(chance.GetName(), new ChanceUi());
            }
        }

        private void AddPropertySquares(BoardMap map, PropertyJson propertyJson)
        {
            // Does not contain Start and Prison so add 2.
            int squareCount = propertyJson.GetCount() + 2;
            
            for (int i = 0; i < squareCount; i++)
            {
                map.MapSquares[i] = propertyJson.Retrieve(i);
                if (map.MapSquares[i] != null)
                {
                    AddController(map.MapSquares[i].GetName(), new PropertyUi());
                }
            }
        }

        public Dictionary<string, AbstractLogics> GetControllers()
        {
            return _controllers;
        }

        private void AddController(string name, AbstractLogics logics)
        {
            _controllers.TryAdd(name, logics);
        }
        
        #endregion
    }
}