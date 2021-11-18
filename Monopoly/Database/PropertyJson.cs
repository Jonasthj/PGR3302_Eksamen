using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;
using Newtonsoft.Json.Linq;

namespace Monopoly.Database
{
    public class PropertyJson
    {

        private JObject _jsonData;

        public PropertyJson(JObject jsonContent)
        {
            // Read JSON file.
            _jsonData = jsonContent;
        }
        
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

        public int GetCount()
        {
            // Remove 1 in properties because of the chance square.
            int properties = _jsonData["Card"].Count() - 1;
            int chances = _jsonData["Card"]["Chance"]["indexList"].Count();

            return properties + chances;
        } 
    }
}