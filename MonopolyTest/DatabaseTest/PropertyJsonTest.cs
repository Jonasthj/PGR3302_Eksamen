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
            string jsonData = exampleData("Grensen", "Brown", 100, 30);

            var jsonContent = JObject.Parse(jsonData);
            
            PropertyJson propertyJson = new PropertyJson(jsonContent);
            
            Assert.That(propertyJson.Retrieve(1).ToString().Contains("Grensen"));
        }

        private string exampleData(string name, string color, int purchase, int rent)
        {
            string example = "{" +
            "'Card': {" +
                "'1': {" +
                    $"'name': '{name}'," +
                    $"'color': '{color}'," +
                    $"'purchase': {purchase}," +
                    $"'rent': {rent}" +
                "}" +
            "}}";

            return @example;
        }
    }
}