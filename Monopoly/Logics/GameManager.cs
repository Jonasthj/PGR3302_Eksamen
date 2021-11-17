using System.Collections.Generic;
using Monopoly.Flyweight;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.PlayerFlyweight.Static;
using Monopoly.Logics.SquareLogics;

namespace Monopoly.Logics
{
    public class GameManager
    {
        public BoardMap Map;
        private readonly PlayerGenerator _generator = PlayerGenerator.GetInstance();
        private Dictionary<string, AbstractLogics> _controllers = new();

        public void InitializeMap()
        {
            CreateBoardMap createBoardMap = new CreateBoardMap();
            
            Map = createBoardMap.Create();
            _controllers = createBoardMap.GetControllers();
        }
        
        
        //Create x players (as defined in menuUI) and put them in start position on boardmap
        public void CreatePlayers(int playersCount)
        {
            for (int i = 1; i < playersCount+1; i++)
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

        public void SetPlayerPos(int playerId, int index)
        {
            Map.Players[playerId] = index;
        }
    }
}