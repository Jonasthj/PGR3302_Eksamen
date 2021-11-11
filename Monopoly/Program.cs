using System;
using System.IO;
using Monopoly.Database;
using Monopoly.UI;
using Newtonsoft.Json.Linq;

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