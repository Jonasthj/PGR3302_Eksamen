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
            MenuUI menu = new();
            menu.StartGame();

        }
    }
}