using System;
using Monopoly.Factory.Classes;
using Monopoly.Flyweight;

namespace Monopoly.UI
{
    public class MenuUI
    {
        private readonly GameManager _manager = new();

        public void StartGame()
        {
            ConsoleOutput.Print("--- Welcome to Monopoly! ---\n");
            ConsoleOutput.Print("How many players are you ( 2-4 )");

            // Set players:
            
            int playersCount = GetPlayerCount();
            _manager.CreatePlayers(playersCount);
            
            SetPlayers(playersCount);
            
            // Print Info (BoardMap, Players + wallet):
            
            /*** NextTurn()
             * Which player?
             * Dice,
             * Show board card
             * Player action (buy, end)
             * End turn
             */
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

            return value;
        }

        private void SetPlayers(int count)
        {
            foreach (var player in PlayerGenerator.Players)
            {
                ConsoleOutput.Print($"Type in name for player {player.Key}");
                string name = ConsoleInput.ReadString();
                
                _manager.SetPlayersInfo(name, player.Key);
            }
            
        }
        
    }
}