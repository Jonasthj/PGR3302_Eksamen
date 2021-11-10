using System.Collections;
using Monopoly.Factory.Classes;
using Monopoly.Factory.Interface;
using Newtonsoft.Json.Linq;

namespace Monopoly.Database
{
    public class ChanceJson
    {
        #region Private fields

        private JObject _jsonData;

        #endregion

        #region Constructors

        public ChanceJson(JObject jsonContent)
        {
            // Read JSON file.
            _jsonData = jsonContent;
        }

        #endregion

        #region Methods

        public ArrayList RetrieveAll()
        {
            // Get the specific card, e.g: Card 1.
            var jsonCard = _jsonData["Card"]["Chance"];

                
            // Only create cards that exist in the json file.
            if(jsonCard != null)
            {
                ArrayList chanceCards = new ArrayList();
                
                JArray indexes = (JArray)jsonCard["indexList"];
                int indexesLength = indexes.Count;

                ArrayList chanceList = new ArrayList();
                
                for (int i = 0; i < indexesLength; i++)
                {
                    int index = (int) indexes[i];
                    
                    JArray chances = (JArray)jsonCard["chanceList"];
                    int chancesLength = chances.Count;

                    for (int j = 0; j < chancesLength; j++)
                    {
                        string text = chances[j]["text"].ToString();
                        int value = (int) chances[j]["value"];
                        int newIndex = (int) chances[j]["newIndex"];

                        chanceList.Add(new ChanceList(text, value, newIndex));
                    }

                    CreateChance chance = new CreateChance(index, chanceList);

                    ISquare square = chance.BuildSquare();
                    chanceCards.Add(square);
                    
                }
                
                return chanceCards;

            }

            return null;
        }

        #endregion
    }
}