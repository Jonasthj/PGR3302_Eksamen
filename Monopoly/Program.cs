
using System;
using System.IO;
using Monopoly.Database;
using Monopoly.Factory.Classes;
using Newtonsoft.Json.Linq;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager game = new GameManager();
            game.CreatePlayers(4);
        }
    }
}