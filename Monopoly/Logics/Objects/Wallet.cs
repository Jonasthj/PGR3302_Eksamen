namespace Monopoly.Logics.Objects
{
    /// <summary>
    /// The Wallet class defines a players balance.
    /// Has override methods for symbols '+' & '-',
    /// so that it directly accesses the Wallet.Balance.
    /// </summary>
    public class Wallet
    {
        public int Balance { get; }
        
        public Wallet(int balance)
        {
            Balance = balance;
        }

        #region Overloads
        
        public static Wallet operator +(Wallet wallet, int value)
        {
            return new Wallet(wallet.Balance + value);
        }
        
        public static Wallet operator -(Wallet wallet, int value)
        {
            return new Wallet(wallet.Balance - value);
        }

        #endregion
        
        public override string ToString()
        {
            return "Balance: " + Balance;
        }
    }
}