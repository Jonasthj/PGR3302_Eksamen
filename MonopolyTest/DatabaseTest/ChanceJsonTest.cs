using System;
using Monopoly.Database;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace MonopolyTest.DatabaseTest
{
    public class ChanceJsonTest
    {
        [Test]
        public void ShouldReturnAllChanceCards()
        {
            string jsonData = ExampleChance();
            
            var jsonContent = JObject.Parse(jsonData);

            ChanceJson chanceJson = new ChanceJson(jsonContent);

            Console.WriteLine(chanceJson.RetrieveAll());
            
        }

        private string ExampleChance()
        {
            return @"
            {
                'Card': {
                    'Chance': {
                        'indexList': [
                            3,
                            6,
                            10
                        ],
                        'chanceList': [
                            {'text': 'Go home', 'value': 100, 'newIndex': 0},
                            {'text': 'Stay', 'value': 0, 'newIndex': 0},
                            {'text': 'Move!', 'value': -50, 'newIndex': 2},
                            {'text': 'Move and become rich', 'value': 200, 'newIndex': 5}
                        ]
                    
                    }
                }
                
            }";
        }
    }
}