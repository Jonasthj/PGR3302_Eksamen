using System.Collections.Generic;

namespace Monopoly
{
    public class BoardMap
    {
        private Dictionary<int, Square> _mapIndex;
        private Dictionary<int, int> _players;

        public Dictionary<int, Square> MapIndex
        {
            get => _mapIndex;
            set => _mapIndex = value;
        }

        //<playerId, index>
        public Dictionary<int, int> Players
        {
            get => _players;
            set => _players = value;
        }
    }
}

