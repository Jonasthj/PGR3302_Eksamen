using System;
using System.Drawing;
using Monopoly.Factory.Classes;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;
using Newtonsoft.Json.Linq;

namespace Monopoly.Database
{
    public class PropertyJson
    {
        #region Private fields

        private JObject _jsonData;

        #endregion

        #region Constructors

        public PropertyJson(JObject jsonContent)
        {
            // Read JSON file.
            _jsonData = jsonContent;
        }

        #endregion

        #region Methods

        public ISquare Retrieve(int id)
        {
            // Get the specific card, e.g: Card 1.
            var jsonCard = _jsonData["Card"][id.ToString()];
                
            // Only create cards that exist in the json file.
            if(jsonCard != null) {
                string name = jsonCard["name"].ToString();
                ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), jsonCard["color"].ToString());
                int buyPrice = (int) jsonCard["buyPrice"];
                int rentPrice = (int) jsonCard["rentPrice"];

                CreateProperty property = new CreateProperty(id, name, color, buyPrice, rentPrice);
                    
                ISquare square = property.BuildSquare();
                
                return square;
            }

            return null;
        }

        #endregion
    }
}