using Monopoly.Database;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace MonopolyTest
{
    public class PropertyJsonTest
    {
        [Test]
        public void ShouldRetrieveCardFromJson()
        {
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