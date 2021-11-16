using System;
using System.CodeDom.Compiler;
using Monopoly.Factory.Classes;
using Monopoly.Flyweight;

namespace Monopoly.UI
{
    public class MenuUI
    {
        private readonly GameManager _manager = new();
        private BoardMap _map = new();

        public void StartGame()
        {
            ConsoleOutput.Print("--- Welcome to Monopoly! ---\n", ConsoleColor.Magenta);
            ConsoleOutput.Print("How many players are you ( 2-4 )", ConsoleColor.Magenta);
            
            _map = _manager.CreateBoardMap();
            
            // Set players:
            
            int playersCount = GetPlayerCount();
            _manager.CreatePlayers(playersCount);
            
            SetPlayers(playersCount);
            
            // Print Info (BoardMap, Players + wallet):
            while (PlayerGenerator.Players.Count > 1)
            {
                PrintState();
            }
        }

        private void PrintState()
        {
            
            ConsoleOutput.PrintNewLine();
            ConsoleOutput.Print(
                "------- Board Map -------\n" +
                $"{_map}", ConsoleColor.Yellow);
            NextTurn(1);
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

            ConsoleOutput.Print("Players set", ConsoleColor.Red);
            
        }

        private void NextTurn(int playerId)
        {
            ConsoleInput.ReadString();
            
            ConsoleOutput.PrintNewLine();
            ConsoleOutput.Print($"Your turn: \n{PlayerGenerator.Players[playerId]}");
            
            ConsoleOutput.PrintNewLine();
            ConsoleOutput.Print("Press enter to roll the dice", ConsoleColor.Cyan);
            
            ConsoleInput.ReadString();
            int diceThrow = Dice.RollDice();
            ConsoleOutput.Print($"You rolled: {diceThrow}", ConsoleColor.Magenta);

            int tmp = _map.Players[playerId] += diceThrow;

            ConsoleOutput.Print(_map.Players[playerId]);

            /*** NextTurn()
         * Dice,
         * Show board card
         * Player action (buy, end)
         * End turn
         */
        }

    }
}