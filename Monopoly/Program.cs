using System;
using System.IO;
using Monopoly.Database;
using Newtonsoft.Json.Linq;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            // JSON Path.
            string jsonPath = @"data.json";
            
            // TODO: Temp directory solution!!!
            Directory.SetCurrentDirectory("../../../../Monopoly/Database/");
            
            // Read JSON file.
            var jsonData = JObject.Parse(File.ReadAllText(jsonPath));
            
            PropertyJson propertyJson = new PropertyJson(jsonData);

            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine(propertyJson.Retrieve(i));
            }
            
        }
    }
}