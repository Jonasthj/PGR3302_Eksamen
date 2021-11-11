using System.Collections.Generic;

namespace Monopoly
{
    public class BoardMap
    {
        public Dictionary<int, string> MapIndex = new Dictionary<int, string>();

        //<playerId, index>
        public static Dictionary<int, int> Players = new Dictionary<int, int>();

    }
}

