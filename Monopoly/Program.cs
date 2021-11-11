using System;
using System.Collections.Generic;
using System.IO;
using Monopoly.Database;
using Monopoly.Factory.Classes;
using Monopoly.Flyweight;
using Newtonsoft.Json.Linq;
using Monopoly.UI;


namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager game = new GameManager();
            
            //Creating players object on boardmap
            int count = Convert.ToInt32(Console.ReadLine());
            game.CreatePlayers(count);
            
            //Setting players values 
            for (int i = 1; i < count+1; i++)
            {
                string name = Console.ReadLine();
                game.FillPlayersInfo(name, i);
            }
            foreach (KeyValuePair<int, Player> player in PlayerGenerator.Players)
            {
                Console.WriteLine("Key: {0}, {1}", 
                    player.Key, player.Value);
            }
            
            PlayerGenerator.Delete(1);
            
            foreach (KeyValuePair<int, Player> player in PlayerGenerator.Players)
            {
                Console.WriteLine("Key: {0}, {1}", 
                    player.Key, player.Value);
            }

            MenuUI menu = new();
            menu.StartGame();

        }
    }
}