using System.Collections.Generic;

namespace Monopoly
{
    public class BoardMap
    {
        public Dictionary<int, string> MapIndex = new ();

        //<playerId, index>
        public Dictionary<int, int> Players = new ();

    }
}

