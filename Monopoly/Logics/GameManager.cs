using System.Collections.Generic;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.PlayerFlyweight;
using Monopoly.Logics.PlayerFlyweight.Abstract;
using Monopoly.Logics.PlayerFlyweight.Static;
using Monopoly.Logics.SquareLogics;

namespace Monopoly.Logics
{
    public sealed class GameManager
    {
        #region Singleton Pattern
        
        private static GameManager _instance = new ();


        private static readonly object Synclock = new ();
        
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
        public readonly PlayerGenerator Generator = PlayerGenerator.GetInstance();
        public bool TaxRaise { get; set; }

        public void InitializeMap(AbstractLogics startLogic, AbstractLogics prisonLogic, AbstractLogics chanceLogic, AbstractLogics propertyLogic)
        {
            CreateBoardMap createBoardMap = new ();
            
            Map = createBoardMap.InitializeMap(startLogic, prisonLogic, chanceLogic, propertyLogic);
            _controllers = createBoardMap.GetControllers();
        }

        //Create x players (as defined in menuUI) and put them in start position on board map.
        public void CreatePlayers(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                Map.Players.Add(i, 0);
                Generator.Get(i);
            }
        }

        public void SetPlayersInfo(string name, int id)
        {
            Player player = Generator.Get(id);
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
        
        public bool IsBlacklisted(int currentPlayerId)
        {
            var blacklisted = Generator.BlackListed;

            foreach (var blacklist in blacklisted)
            {
                if (currentPlayerId == blacklist.Id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}