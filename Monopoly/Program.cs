using System;
using System.IO;
using Monopoly.Database;
using Newtonsoft.Json;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Card1 card1 = new();
            Card2 card2 = new();
            
            card1.CreateCard();
            card2.CreateCard();

            File.WriteAllText(@"data.json", JsonConvert.SerializeObject(card1));
            
            // read file into a string and deserialize JSON to a type
            Card1 newCard1 = JsonConvert.DeserializeObject<Card1>(File.ReadAllText(@"data.json"));
            
            Console.WriteLine(newCard1.ToString());
            


        }
    }
}