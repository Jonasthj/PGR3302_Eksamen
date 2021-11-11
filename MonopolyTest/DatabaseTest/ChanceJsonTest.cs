using System;
using System.IO;
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
            var jsonContent = JsonFileReader.GetJsonData();
            
            ChanceJson chanceJson = new ChanceJson(jsonContent);

            
            Assert.True(chanceJson.RetrieveAll()[0].ToString().Contains("3"));
            Assert.True(chanceJson.RetrieveAll()[0].ToString().Contains("Move to start and collect 100"));
            
            Assert.True(chanceJson.RetrieveAll()[1].ToString().Contains("6"));
            Assert.True(chanceJson.RetrieveAll()[1].ToString().Contains("Go directly to prison and skip one round"));
            
            Assert.True(chanceJson.RetrieveAll()[2].ToString().Contains("13"));


        }
    }
}