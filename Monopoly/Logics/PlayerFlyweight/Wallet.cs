namespace Monopoly.Logics.PlayerFlyweight
{
    public class Wallet
    {
        /// <summary>
        /// The Wallet class defines a players balance.
        /// Has override methods for symbols '+' & '-',
        /// so that it directly accesses the Wallet.Balance
        /// </summary>

        public int Balance { get; }
        
        
        #region Methods
        
        public Wallet(int balance)
        {
            Balance = balance;
        }

        public static Wallet operator +(Wallet wallet, int value)
        {
            return new Wallet(wallet.Balance + value);
        }
        
        public static Wallet operator -(Wallet wallet, int value)
        {
            return new Wallet(wallet.Balance - value);
        }
        
        public override string ToString()
        {
            return "Balance: " + Balance;
        }

        #endregion
    }
}