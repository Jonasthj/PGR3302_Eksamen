using System.Collections.Generic;
using Monopoly.Database;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.SquareLogics;

namespace Monopoly.Logics
{
    public class CreateBoardMap
    {
        private readonly Dictionary<string, AbstractLogics> _controllers = new();
        private BoardMap _map;
        
        #region Methods

        public BoardMap InitializeMap(AbstractLogics startLogic, AbstractLogics prisonLogic, AbstractLogics chanceLogic, AbstractLogics propertyLogic)
        {
            _map = new BoardMap();

            // AddPropertySquares sets the MapSquares.length.
            var properties = AddPropertySquares(new PropertyJson());
            var chances = AddChanceSquares(new ChanceJson());
            var start = AddStartSquare();
            var prison = AddPrisonSquare();

            foreach (var chance in chances)
            {
                AddController(chance.GetName(), chanceLogic);
            }

            foreach (var property in properties)
            {
                AddController(property.GetName(), prisonLogic);
            }

            AddController(start.GetName(), startLogic);
            AddController(prison.GetName(), prisonLogic);
            
            return _map;

        }
        
        private void AddController(string name, AbstractLogics logics)
        {
            _controllers.TryAdd(name, logics);
        }

        private Prison AddPrisonSquare()
        
        {
            Prison prison = new Prison();
            _map.MapSquares[prison.Id] = prison;

            return prison;
        }

        private Start AddStartSquare()
        {
            Start start = new Start();
            _map.MapSquares[start.Id] = start;

            return start;
        }

        private List<Chance> AddChanceSquares(ChanceJson chanceJson)
        {
            List<Chance> chances = new List<Chance>();
            foreach (var square in chanceJson.RetrieveAll())
            {
                Chance chance = (Chance) square;
                _map.MapSquares[chance.Id] = chance;
                chances.Add(chance);
            }

            return chances;
        }

        private List<Property> AddPropertySquares(PropertyJson propertyJson)
        {
            // Does not contain Start and Prison so add 2.
            int squareCount = propertyJson.GetCount() + 2;

            List<Property> properties = new List<Property>();

            for (int i = 0; i < squareCount; i++)
            {
                _map.MapSquares[i] = propertyJson.Retrieve(i);
                if (_map.MapSquares[i] != null)
                {
                    Property property = (Property) _map.MapSquares[i];
                    properties.Add(property);
                }
            }

            return properties;
        }

        public Dictionary<string, AbstractLogics> GetControllers()
        {
            return _controllers;
        }

        #endregion
    }
}