using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Flyweight
{
    public static class PlayerGenerator
    {
        private static readonly Dictionary<int, Player> Players = new();
        public static Player Get(int id)
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
    }
}