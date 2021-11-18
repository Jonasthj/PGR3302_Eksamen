namespace Monopoly.Logics.SquareLogics
{
    public class StartLogics
    {
        private const int Collect = 100;

        public void HandleStartLogic(int playerId)
        {
            WalletCalculator calculator = new();
            calculator.AddBalance(playerId, Collect);
        }
    }
}