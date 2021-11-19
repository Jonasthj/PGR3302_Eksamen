using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Logics;
using Monopoly.Logics.PlayerFlyweight.Abstract;

namespace Monopoly.UI
{
    public class MenuUi
    {
        /// <summary>
        /// MenuUi handles all the interaction between the user and the program.
        /// The class only communicates with GameManager who handles the rest of the logic.
        /// </summary>
        
        private readonly GameManager _manager = GameManager.GetInstance();
        private int _currentPlayerId = 1;

        #region Methods
        
        public void StartGame()
        {
            _manager.InitializeMap();
            
            WelcomeMessage();

            // Set players:
            int playersCount = _manager.GetPlayerCount();
            _manager.CreatePlayers(playersCount);
            SetPlayers();
        
            // See the start positions.
            PrintMap();

            PlayGame();
        }

        private void PlayGame()
        {
            // Print Info (BoardMap, Players + wallet):
            int playerAmount = _manager.Generator.Players.Count;
            int blacklistCount = _manager.Generator.BlackListed.Count;

            while (playerAmount - blacklistCount > 1)
            {
                CheckBlacklist();
                playerAmount = _manager.Generator.Players.Count;
                blacklistCount = _manager.Generator.BlackListed.Count;
            }

            PlayerWin();
        }

        private static void WelcomeMessage()
        {
            ConsoleOutput.Print("--- Welcome to Monopoly! ---", ConsoleColor.Magenta);
            ConsoleOutput.Print("How many players are you ( 2-4 )", ConsoleColor.Magenta);
        }

        private void SetPlayers()
        {
            foreach (var player in _manager.Generator.Players)
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
            var winner = GetWinner();

            ConsoleOutput.Print("----------------------------------------------", ConsoleColor.Green);
            ConsoleOutput.Print($"Congratulation! You won the game!", ConsoleColor.Yellow);
            ConsoleOutput.Print(winner.ToString(), ConsoleColor.Yellow);
            ConsoleOutput.Print("----------------------------------------------", ConsoleColor.Green);
        }

        private Player GetWinner()
        {
            var players = _manager.Generator.Players;
            var blacklisted = _manager.Generator.BlackListed;

            List<int> playerIds = new List<int>();
            foreach (var player in players)
            {
                playerIds.Add(player.Key);
            }

            List<int> blacklistId = new List<int>();
            foreach (var player in blacklisted)
            {
                blacklistId.Add(player.Id);
            }

            var winnerId = playerIds.Except(blacklistId);

            Player winner = _manager.Generator.Get(winnerId.First());
            return winner;
        }

        private void PrintPlayerInfo(int playerId)
        {
            ConsoleOutput.Print($"{_manager.Generator.Players[playerId]}", ConsoleColor.White);
        }

        private bool IsBlacklisted()
        {
            var blacklisted = _manager.Generator.BlackListed;

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
            var blacklisted = _manager.Generator.BlackListed;

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
            
            if (_currentPlayerId > _manager.Generator.Players.Count)
                _currentPlayerId = 1;
        }

        private void NextTurn(int playerId)
        {
            // Player starts next turn.
            ConsoleOutput.PrintEnter();
            ConsoleInput.ReadKey();
            _currentPlayerId++;
            Console.Clear();
            
            ConsoleOutput.Print("Your turn:", ConsoleColor.White);
            PrintPlayerInfo(playerId);

            bool playerInPrison = _manager.Generator.Get(playerId).InPrison;
            
            if (!playerInPrison)
            {
                
                ConsoleOutput.Print("Press enter to roll the dice", ConsoleColor.Cyan);
                ConsoleInput.ReadKey();

                var diceThrow = Dice.RollDice();
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
        
        #endregion
    }
}