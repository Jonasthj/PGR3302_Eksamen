using System.Drawing;
using Monopoly.Database;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace MonopolyTest.DatabaseTest
{
    public class PropertyJsonTest
    {
        [Test]
        public void ShouldRetrieveCardFromJson()
        {
            string jsonData = exampleData(1, "Grensen", "Brown", 100, 30);

            var jsonContent = JObject.Parse(jsonData);
            
            PropertyJson propertyJson = new PropertyJson(jsonContent);
            
            Assert.That(propertyJson.Retrieve(1).ToString().Contains("Grensen"));
        }

        private string exampleData(int id, string name, string color, int buyPrice, int rentPrice)
        {
            string example = @"
            {
                'Card': {
                    '" + id + @"': {
                        'name': '" + name + @"',
                        'color': '" + color + @"',
                        'buyPrice': " + buyPrice + @",
                        'rentPrice': " + rentPrice + @"
                    }
                }
            }";

            return example;
        }
    }
}