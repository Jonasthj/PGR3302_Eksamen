using System;

namespace Monopoly.Flyweight
{
    public abstract class Player
    {
        protected int Id;
        public string Name { get; private set; }
        public Wallet Wallet { get; private set; }
        public bool InPrison { get; private set; }

        public virtual void SetExtrinsicPart(string name, Wallet wallet, bool inPrison)
        {
            Name = name;
            Wallet = wallet;
            InPrison = inPrison;
        }

        public override string ToString()
        {
            return "Id: " + Id + "\n" +
                   "Name: " + Name + "\n" +
                   "Balance: " + Wallet.Balance;
        }
    }
}