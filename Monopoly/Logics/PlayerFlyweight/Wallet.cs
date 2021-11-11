using System;

namespace Monopoly.Flyweight
{
    public class Wallet
    {
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

        public override string ToString()
        {
            return "Balance: " + Balance;
        }
        
        // TODO: Operator overloads?

        #endregion
    }
}