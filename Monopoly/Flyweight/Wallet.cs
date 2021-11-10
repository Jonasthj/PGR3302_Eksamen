namespace Monopoly.Flyweight
{
    public class Wallet
    {
        public int Balance { get; }
        
        public Wallet(int balance)
        {
            Balance = balance;
        }
        
        public override string ToString()
        {
            return "Balance: " + Balance;
        }
    }
}