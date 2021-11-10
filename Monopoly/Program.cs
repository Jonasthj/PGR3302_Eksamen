using System;
using System.Drawing;
using System.IO;
using Monopoly.Factory.Classes;
using Monopoly.Factory.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {

            // JSON Path.
            string jsonData = @"../../../Database/data.json";

            // Read JSON file.
            var details = JObject.Parse(File.ReadAllText(jsonData));


            for (int i = 1; i < 16; i++)
            {
                if(details["Card"][i.ToString()] != null) {
                    
                    string name = details["Card"][i.ToString()]["name"].ToString();
                    Color color = Color.FromName(details["Card"][i.ToString()]["color"].ToString());
                    int purchase = (int) details["Card"][i.ToString()]["purchase"];
                    int rent = (int) details["Card"][i.ToString()]["rent"];

                    CreateProperty property = new CreateProperty(i, name, color, purchase, rent);
                    
                    ISquare square = property.BuildSquare();
                    
                    // Print all properties.
                    Console.WriteLine(square);
                } 


            }


        }
    }
}