using System.Collections;
using System.Collections.Generic;
using System.Text;
using Monopoly.Factory.Interface;
using Monopoly.UI;

namespace Monopoly
{
    public class BoardMap
    {
        // <mapIndex, Square>
        public Dictionary<int, ISquare> MapSquares = new ();

        // <playerId, index>
        public Dictionary<int, int> Players = new ();
        
        // Visual display of the squares with all the players positions.
        public ArrayList BoardSquares { get; set; }

        private string horSpace = "---";
        private string verSpace = "|";
        
        // The difference between the left side of the map and the right side.
        // Is decided when creating one of the horizontal sides.
        private int sideDifference;
        
        private void InitializeSquares()
        {
            BoardSquares = new ();
            
            // Players.Add(0, 1);
            // Players.Add(1, 0);
            // Players.Add(2, 14);
            // Players.Add(3, 14);
            
            // TODO: Change length to MapIndex.Count
            for (int i = 0; i < 20; i++)
            {
                BoardSquares.Add("[]");
            }

            sideDifference = 1;
        }
        
        private string MakeHorizontalMapTop(int firstIndex, int lastIndex)
        {
            StringBuilder map = new StringBuilder();
            
            for (int i = firstIndex; i <= lastIndex; i++)
            {
                foreach (KeyValuePair<int, int> player in Players)
                {
                    MovePlayerPos(i, player);
                }

                map.Append($"{BoardSquares[i]}");

                if (i != lastIndex)
                    map.Append($"{horSpace}");

                sideDifference++;
            }

            map.Append("\n");

            return map.ToString();
        }

        private string MakeHorizontalMapBotttom(int firstIndex, int lastIndex)
        {
            StringBuilder map = new StringBuilder();
            
            for (int i = lastIndex; i >= firstIndex; i--)
            {

                foreach (KeyValuePair<int, int> player in Players)
                {
                    MovePlayerPos(i, player);
                }

                map.Append($"{BoardSquares[i]}");

                if (i != firstIndex)
                    map.Append($"{horSpace}");

            }

            return map.ToString();
        }

        private string MakeVerticalMap(int firstIndex, int lastIndex)
        {
            StringBuilder map = new StringBuilder();

            for (int i = lastIndex; i > firstIndex; i--)
            {
                foreach (KeyValuePair<int, int> player in Players)
                {
                    MovePlayerPos(i, player);
                    MovePlayerPos(lastIndex + sideDifference, player);
                }

                map.Append($"{verSpace}			  {verSpace}\n");
                map.Append($"{BoardSquares[i]}");
                map.Append("		    	 ");
                map.Append($"{BoardSquares[lastIndex + sideDifference]}\n");
                sideDifference++;
            }

            map.Append($"{verSpace}			  {verSpace}\n");
                
            return map.ToString();
        }

        private void MovePlayerPos(int i, KeyValuePair<int, int> player)
        {
            // Change the bordSquare-string if there are any players in it.
            if (i == player.Value)
            {
                if (BoardSquares[i].Equals("[]"))
                    BoardSquares[i] = $"[{player.Key}]";
                else
                {
                    string prevPlayer = BoardSquares[i].ToString().TrimEnd(']');
                    BoardSquares[i] = $"{prevPlayer}, {player.Key}]";
                }
            }
        }

        public override string ToString()
        {
            InitializeSquares();

            // string map = "";
            StringBuilder map = new StringBuilder();

            map.Append(MakeHorizontalMapTop(10, 15));
            map.Append(MakeVerticalMap(5, 9));
            map.Append(MakeHorizontalMapBotttom(0, 5));

            return map.ToString();
        }
    }
}

