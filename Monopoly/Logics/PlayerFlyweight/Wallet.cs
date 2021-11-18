using System;

namespace Monopoly.Flyweight
{
    public class Wallet
    {
        /// <summary>
        /// The Wallet class defines a players balance.
        /// Has override methods for symbols '+' & '-',
        /// so that it directly accesses the Wallet.Balance
        /// </summary>
        #region Properties

        public int Balance { get; }

        #endregion

        #region Constructor

        public Wallet(int balance)
        {
            Balance = balance;
        }

        #endregion

        #region Overrides

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