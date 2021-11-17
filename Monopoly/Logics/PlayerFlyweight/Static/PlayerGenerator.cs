using System;
using System.Collections.Generic;
using Monopoly.Flyweight;

namespace Monopoly.Logics.PlayerFlyweight.Static
{
    public sealed class PlayerGenerator
    {
        #region Singleton Pattern
        
        private static PlayerGenerator _instance = new PlayerGenerator();


        private static readonly object Synclock = new object();
        
        public static PlayerGenerator GetInstance()
        {
            if (_instance == null)
            {
                lock (Synclock)
                {
                    _instance = new PlayerGenerator();
                }
            }
            return _instance;
        }

        private PlayerGenerator()
        {
            // Private Constructor
        }
        
        #endregion

        
        public readonly Dictionary<int, Player> Players = new();
        public Player Get(int id)
        {
            Player player = null;
            if (Players.ContainsKey(id))
            {
                player = Players[id];
            }
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

        public void Delete(int id)
        {
            Players.Remove(id);
        }
    }
}