using System;
using System.Drawing;
using System.IO;
using Monopoly.Database;
using Monopoly.Factory.Classes;
using Monopoly.Factory.Interface;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace MonopolyTest
{
    public class PropertyJsonTest
    {
        // JSON Path.
        private string jsonPath = @"data.json";

        [Test]
        public void ShouldRetrieveCardFromJson()
        {
            // // TODO: Temp directory solution!!!
            // Directory.SetCurrentDirectory("../../../../Monopoly/Database/");
            //
            // // Read JSON file.
            // var _jsonData = JObject.Parse(File.ReadAllText(jsonPath));
            
            string jsonData = @"{
                'Card': {
                    '1': {
                        'name': 'Grensen',
                        'color': 'Brown',
                        'purchase': 100,
                        'rent': 30
                    }
                }}";

            var jsonContent = JObject.Parse(jsonData);
            
            PropertyJson propertyJson = new PropertyJson(jsonContent);
            
            Assert.That(propertyJson.Retrieve(1).ToString().Contains("Grensen"));
        }
    }
}