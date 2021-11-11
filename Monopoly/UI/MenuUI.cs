using System;
using Monopoly.Factory.Classes;

namespace Monopoly.UI
{
    public class MenuUI
    {

        public void StartGame()
        {
            GameManager manager = new();
            
            ConsoleOutput.Print("--- Welcome to Monopoly! ---\n");
            ConsoleOutput.Print("How many players are you ( 2-4 )");

            int playersCount = GetPlayerCount();
            
            manager.CreatePlayers(playersCount);
            
        }

        private void PrintState()
        {
            
        }

        private int GetPlayerCount()
        {
            int value = 0;
            bool playersSet = false;
            
            while (!playersSet)
            {
                value = ConsoleInput.ReadInt();

                if (value is >= 2 and <= 4)
                    playersSet = true;
                else
                    ConsoleOutput.Print("- You must be minimum 2 players and maximum 4!");
            }
            
            ConsoleOutput.Print($"You are {value} players!");

            return value;
        }
        
    }
}