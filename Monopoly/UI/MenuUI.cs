using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Monopoly.Factory.Classes;
using Monopoly.Flyweight;
using Monopoly.Logics;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.PlayerFlyweight.Static;

namespace Monopoly.UI
{
    public class MenuUI
    {
        private PlayerGenerator _generator = PlayerGenerator.GetInstance();
        private readonly GameManager _manager = new();
        private int _currentPlayerId = 1;

        public void StartGame()
        {
            _manager.InitializeMap();
            
            ConsoleOutput.Print("--- Welcome to Monopoly! ---\n", ConsoleColor.Magenta);
            ConsoleOutput.Print("How many players are you ( 2-4 )", ConsoleColor.Magenta);

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
            ConsoleOutput.Print("------- Board Map -------\n" + $"{_manager.Map}", ConsoleColor.Yellow);

            if (_currentPlayerId >= _manager.Map.Players.Count + 1)
                _currentPlayerId = 1;
            
            NextTurn(_currentPlayerId);


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
            foreach (var player in _generator.Players)
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
            _currentPlayerId++;
            Console.Clear();

            ConsoleOutput.PrintNewLine();
            ConsoleOutput.Print($"Your turn: \n{_generator.Players[playerId]}");
            
            ConsoleOutput.PrintNewLine();
            ConsoleOutput.Print("Press enter to roll the dice", ConsoleColor.Cyan);
            
            ConsoleInput.ReadString();
            int diceThrow = Dice.RollDice();
            ConsoleOutput.Print($"You rolled: {diceThrow}", ConsoleColor.Magenta);
            
            MovePlayer(playerId, diceThrow);
            
            int playerIndex = _manager.Map.Players[playerId];
            
            _manager.SquareController(playerIndex, playerId);

            /*** NextTurn()
         * Player action (buy, end)
         * End turn
         */

        }

        private void MovePlayer(int playerId, int diceThrow)
        {
            int playerIndex = _manager.Map.Players[playerId];
            int newIndex = diceThrow + playerIndex;
            int squareCount = _manager.Map.BoardSquares.Count;

            if (newIndex >= squareCount)
            {
                int restSquares = squareCount - playerIndex;
                int move = diceThrow - restSquares;
                _manager.Map.Players[playerId] = move;
                
                if(move != 0)
                    _manager.SquareController(0, playerId);
            }
            else
                _manager.Map.Players[playerId] += diceThrow;
        }
    }
}