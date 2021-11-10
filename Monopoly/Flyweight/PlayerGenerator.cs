using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Flyweight
{
    public class PlayerGenerator
    {
        private readonly Dictionary<int, Player> _players = new();
        public Player Get(int id)
        {
            Player player = null;
            if (_players.ContainsKey(id))
            {
                player = _players[id];
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
                }
                _players.Add(id, player);
            }

            return player;

        }
    }
}