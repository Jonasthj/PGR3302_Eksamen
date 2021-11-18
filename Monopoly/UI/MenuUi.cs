using System;
using System.Collections.Generic;
using Monopoly.Logics;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.PlayerFlyweight.Abstract;
using Monopoly.Logics.PlayerFlyweight.Static;

namespace Monopoly.UI
{
    public class MenuUi
    {
        private readonly PlayerGenerator _generator = PlayerGenerator.GetInstance();
        private readonly GameManager _manager = GameManager.GetInstance();
        private int _currentPlayerId = 1;

        public void StartGame()
        {
            _manager.InitializeMap();
            
            WelcomeMessage();

            // Set players:
            int playersCount = _manager.GetPlayerCount();
            _manager.CreatePlayers(playersCount);
            SetPlayers(playersCount);
            
            // See the start positions.
            PrintMap();

            PlayGame();
        }

        private void PlayGame()
        {
            // Print Info (BoardMap, Players + wallet):
            int playerAmount = PlayerGenerator.GetInstance().Players.Count;
            int blacklistCount = PlayerGenerator.GetInstance().BlackListed.Count;

            while (playerAmount - blacklistCount > 1)
            {
                CheckBlacklist();
                playerAmount = PlayerGenerator.GetInstance().Players.Count;
                blacklistCount = PlayerGenerator.GetInstance().BlackListed.Count;
            }

            PlayerWin();
        }

        private static void WelcomeMessage()
        {
            ConsoleOutput.Print("--- Welcome to Monopoly! ---", ConsoleColor.Magenta);
            ConsoleOutput.Print("How many players are you ( 2-4 )", ConsoleColor.Magenta);
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

        private void PrintMap()
        {
            ConsoleOutput.Print("------- Board Map -------\n" + $"{_manager.Map}", ConsoleColor.Yellow);
        }

        private void PlayerWin()
        {
            Player winner = PlayerGenerator.GetInstance().Get(_currentPlayerId);
            
            ConsoleOutput.Print("----------------------------------------------", ConsoleColor.Green);
            ConsoleOutput.Print($"Congratulation! You won the game!", ConsoleColor.Yellow);
            ConsoleOutput.Print(winner.ToString(), ConsoleColor.Yellow);
            ConsoleOutput.Print("----------------------------------------------", ConsoleColor.Green);
        }

        private void PrintPlayerInfo(int playerId)
        {
            ConsoleOutput.Print($"{_generator.Players[playerId]}", ConsoleColor.White);
        }

        private bool IsBlacklisted()
        {
            var blacklisted = PlayerGenerator.GetInstance().BlackListed;

            foreach (var blacklist in blacklisted)
            {
                if (_currentPlayerId == blacklist.Id)
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckBlacklist()
        {
            var blacklisted = PlayerGenerator.GetInstance().BlackListed;

            if (blacklisted.Count > 0)
            {
                if (!IsBlacklisted())
                {
                    NextTurn(_currentPlayerId);
                }
                else
                {
                    _currentPlayerId++;
                }
            }
            else
            {
                NextTurn(_currentPlayerId);
            }
            
            if (_currentPlayerId > PlayerGenerator.GetInstance().Players.Count)
                _currentPlayerId = 1;
        }

        private void NextTurn(int playerId)
        {
            // Player starts next turn.
            ConsoleOutput.PrintEnter();
            ConsoleInput.ReadString();
            _currentPlayerId++;
            Console.Clear();
            
            ConsoleOutput.Print("Your turn:", ConsoleColor.White);
            PrintPlayerInfo(playerId);

            bool playerInPrison = PlayerGenerator.GetInstance().Get(playerId).InPrison;
            
            if (!playerInPrison)
            {
                Dice dice = new Dice();

                ConsoleOutput.Print("Press enter to roll the dice", ConsoleColor.Cyan);
                ConsoleInput.ReadString();

                var diceThrow = dice.RollDice();
                ConsoleOutput.Print($"You rolled: {diceThrow}", ConsoleColor.Magenta);
            
                _manager.MovePlayer(playerId, diceThrow);
                var playerIndex = _manager.Map.Players[playerId];
                PrintMap();

                _manager.SquareController(playerIndex, playerId);
                
                int newIndex = _manager.Map.Players[playerId];
                if (playerIndex != newIndex)
                {
                    Console.Clear();
                    PrintMap();
                }

                PrintPlayerInfo(playerId);
                ConsoleOutput.Print("Your turn has ended", ConsoleColor.Red);
            }
            else
            {
                PrisonController(playerId);
            }
            
        }

        private void PrisonController(int playerId)
        {
            var boardMap = _manager.Map.MapSquares;
            foreach (var square in boardMap)
            {
                if (square.Value.GetName().Equals("Prison"))
                    _manager.SquareController(square.Key, playerId);
            }
        }
    }
}