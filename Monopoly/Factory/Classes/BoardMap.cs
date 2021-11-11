using System.Collections.Generic;

namespace Monopoly
{
    public class BoardMap
    {
        private Dictionary<int, string> _mapIndex;
        private Dictionary<int, int> _players;

        public Dictionary<int, string> MapIndex { get; set; }

        //<playerId, index>
        public Dictionary<int, int> Players { get; set; }
    }
}

