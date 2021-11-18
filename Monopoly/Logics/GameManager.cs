using System.Collections.Generic;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.PlayerFlyweight;
using Monopoly.Logics.PlayerFlyweight.Abstract;
using Monopoly.Logics.PlayerFlyweight.Static;
using Monopoly.Logics.SquareLogics;
using Monopoly.UI;

namespace Monopoly.Logics
{
    public sealed class GameManager
    {
        #region Singleton Pattern
        
        private static GameManager _instance = new GameManager();


        private static readonly object Synclock = new object();
        
        public static GameManager GetInstance()
        {
            if (_instance == null)
            {
                lock (Synclock)
                {
                    _instance = new GameManager();
                }
            }
            return _instance;
        }

        private GameManager()
        {
            // Private Constructor
        }

        #endregion

        public BoardMap Map;
        private Dictionary<string, AbstractLogics> _controllers = new();
        private readonly PlayerGenerator _generator = PlayerGenerator.GetInstance();

        public void InitializeMap()
        {
            CreateBoardMap createBoardMap = new CreateBoardMap();
            
            Map = createBoardMap.Create();
            _controllers = createBoardMap.GetControllers();
        }
        
        public int GetPlayerCount()
        {
            int value = 0;
            bool playersSet = false;
            
            while (!playersSet)
            {
                value = ConsoleInput.ReadInt();

                if (value is >= 2 and <= 4)
                    playersSet = true;
                else
                    ConsoleOutput.Print("- You must be minimum 2 players and maximum 4!");
            }

            return value;
        }
        
        //Create x players (as defined in menuUI) and put them in start position on board map.
        public void CreatePlayers(int playersCount)
        {
            for (int i = 1; i <= playersCount; i++)
            {
                Map.Players.Add(i, 0);
                _generator.Get(i);
            }
        }

        public void SetPlayersInfo(string name, int id)
        {
            Player player = _generator.Get(id);
            player.SetExtrinsicPart(name, new Wallet(600), false);
        }

        public void SquareController(int playerIndex, int playerId)
        {
            ISquare mapSquare = Map.MapSquares[playerIndex];
            if (_controllers.ContainsKey(mapSquare.GetName()))
            {
                _controllers[mapSquare.GetName()].Handle(mapSquare, playerId);
            }
        }

        public void MovePlayer(int playerId, int diceThrow)
        {
            int playerIndex = Map.Players[playerId];
            int newIndex = diceThrow + playerIndex;
            int squareCount = Map.BoardSquares.Count;

            if (newIndex >= squareCount)
            {
                int restSquares = squareCount - playerIndex;
                int move = diceThrow - restSquares;
                Map.Players[playerId] = move;
                
                if(move != 0)
                    SquareController(0, playerId);
            }
            else
                Map.Players[playerId] += diceThrow;
        }
    }
}