using System;
using System.Collections.Generic;
using Monopoly.Logics.PlayerFlyweight.Abstract;
using Monopoly.Logics.PlayerFlyweight.Players;

namespace Monopoly.Logics.PlayerFlyweight.Singleton
{
    /// <summary>
    /// The Flyweight-"Factory" class, also uses the singleton design pattern - 
    /// In order to globally make available the same instance of PlayerGenerator.
    /// PlayerGenerator both stores and creates Players. 
    /// </summary>
    
    public sealed class PlayerGenerator
    {
        #region Singleton Pattern
        
        private static PlayerGenerator _instance = new();
        
        private static readonly object SyncLock = new();
        
        public static PlayerGenerator GetInstance()
        {
            if (_instance == null)
            {
                lock (SyncLock)
                    _instance = new PlayerGenerator();
            }
            return _instance;
        }

        private PlayerGenerator()
        {
            // Private Constructor
        }
        
        #endregion

        public readonly Dictionary<int, Player> Players = new();
        public readonly HashSet<Player> BlackListed = new ();

        /// <description>
        ///  Either returns the existing player, or returns a newly created one.
        /// </description>
        public Player Get(int id)
        {
            Player player;
            if (Players.ContainsKey(id))
                player = Players[id];
            else
            {
                switch (id)
                {
                    case 1:
                        player = new Player1();
                        break;
                    case 2:
                        player = new Player2();
                        break;
                    case 3:
                        player = new Player3();
                        break;
                    case 4:
                        player = new Player4();
                        break;
                    default:
                        throw new IndexOutOfRangeException("Max amount of players is 4!");
                }
                Players.Add(id, player);
            }
            return player;
        }

        public void Blacklist(int id)
        {
            BlackListed.Add(Get(id));            
        }
    }
}