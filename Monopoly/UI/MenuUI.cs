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
        private int currentPlayerId = 1;

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
            while (playersCount > 1)
            {
                PrintState();
            }
        }

        private void PrintState()
        {
            ConsoleOutput.PrintNewLine();
            ConsoleOutput.Print("------- Board Map -------\n" + $"{_map}", ConsoleColor.Yellow);

            if (currentPlayerId >= _map.Players.Count + 1)
                currentPlayerId = 1;
            
            NextTurn(currentPlayerId);


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
            // Player starts next turn.
            ConsoleInput.ReadString();
            currentPlayerId++;

            Console.Clear();

            ConsoleOutput.PrintNewLine();
            ConsoleOutput.Print($"Your turn: \n{PlayerGenerator.Players[playerId]}");
            
            ConsoleOutput.PrintNewLine();
            ConsoleOutput.Print("Press enter to roll the dice", ConsoleColor.Cyan);
            
            ConsoleInput.ReadString();
            int diceThrow = Dice.RollDice();
            ConsoleOutput.Print($"You rolled: {diceThrow}", ConsoleColor.Magenta);
            
            MovePlayer(playerId, diceThrow);
            
            int playerIndex = _map.Players[playerId];
            ConsoleOutput.Print(_map.MapSquares[playerIndex].ToString());
            
            /*** NextTurn()
         * Player action (buy, end)
         * End turn
         */

        }

        private void MovePlayer(int playerId, int diceThrow)
        {
            int playerIndex = _map.Players[playerId];
            int newIndex = diceThrow + playerIndex;
            int squareCount = _map.BoardSquares.Count;

            if (newIndex >= squareCount)
            {
                int restSquares = squareCount - playerIndex;
                int move = diceThrow - restSquares;
                _map.Players[playerId] = move;
            }
            else
                _map.Players[playerId] += diceThrow;
        }
    }
}