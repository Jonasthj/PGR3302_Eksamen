using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Monopoly.UI;

namespace Monopoly
{
    public class BoardMap
    {
        public Dictionary<int, string> MapIndex = new ();

        //<playerId, index>
        public Dictionary<int, int> Players = new ();
        
        private string hor = "---";
        private string ver = "|";
        private int verticalDiff = 1;

        private ArrayList _boardSquares = new ();

        private void Test()
        {
            Players.Add(0, 0);
            Players.Add(1, 11);
            Players.Add(2, 19);

            for (int i = 0; i < 20; i++)
            {
                _boardSquares.Add("[]");
            }
        }
        
        private string MakeHorizontalMapTop(int firstIndex, int lastIndex, Dictionary<int, int> players)
        {
            string map = "";

            for (int i = firstIndex; i < lastIndex; i++)
            {

                foreach (KeyValuePair<int, int> player in players)
                {
                    if (i == player.Value)
                    {
                        _boardSquares[i] = $"[pos: {player.Value}, player: {player.Key}]";

                    }

                    if (player.Value == lastIndex)
                    {
                        _boardSquares[lastIndex] = $"[pos: {player.Value}, player: {player.Key}]";
                    }

                }

                
                    
                
                map += $"{_boardSquares[i]}{hor}";
                
                if (i == lastIndex - 1)
                {
                    map += $"{_boardSquares[lastIndex]}";
                    verticalDiff++;
                }
                
                verticalDiff++;
            }

            return map;
        }
        
        private string MakeHorizontalMapBotttom(int firstIndex, int lastIndex, Dictionary<int, int> players)
        {
            string map = "";

            for (int i = lastIndex; i > firstIndex; i--)
            {

                foreach (KeyValuePair<int, int> player in players)
                {
                    if (i == player.Value)
                    {
                        _boardSquares[i] = $"[pos: {player.Value}, player: {player.Key}]";
                    }
                    
                    if (player.Value == firstIndex)
                    {
                        _boardSquares[firstIndex] = $"[pos: {player.Value}, player: {player.Key}]";

                    }
                }
                
                map += $"{_boardSquares[i]}{hor}";
                
                if (i == firstIndex + 1)
                {
                    map += $"{_boardSquares[firstIndex]}";
                }

            }

            return map;
        }

        private string MakeVerticalMap(int firstIndex, int lastIndex, Dictionary<int, int> players)
        {
            string map = "";

            for (int i = lastIndex; i > firstIndex; i--)
            {
                foreach (KeyValuePair<int, int> player in players)
                {
                    if (i == player.Value)
                    {
                        _boardSquares[i] = $"[pos: {player.Value}, player: {player.Key}]";

                    }
                    if (lastIndex + verticalDiff == player.Value)
                    {
                        _boardSquares[lastIndex + verticalDiff] = $"[pos: {player.Value}, player: {player.Key}]";

                    }
                    
                }

                

                map += $"{ver}			  {ver}\n";
                map += $"{_boardSquares[i]}			 {_boardSquares[lastIndex + verticalDiff]}\n";
                verticalDiff++;
            }
            
            map += $"{ver}			  {ver}\n";
            

            return map;
        }
        
        public override string ToString()
        {

            Test();

            string map = "";

            int i = 1;
            
            map += MakeHorizontalMapTop(10, 15, Players);

            map += "\n";

            map += MakeVerticalMap(5, 9, Players);

            map += MakeHorizontalMapBotttom(0, 5, Players);
            
            
            
            return map;
        }
    }
}

