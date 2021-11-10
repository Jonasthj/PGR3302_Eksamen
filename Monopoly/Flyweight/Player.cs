using System;

namespace Monopoly.Flyweight
{
    public abstract class Player
    {
        protected int Id;
        protected string Name;
        private Wallet _wallet;

        public virtual void SetExtrinsicPart(string name, Wallet wallet)
        {
            Name = name;
            _wallet = wallet;
        }

        public override string ToString()
        {
            return "Id: " + Id + "\n" +
                   "Name: " + Name + "\n" +
                   "Balance: " + _wallet.Balance;
        }
    }
}