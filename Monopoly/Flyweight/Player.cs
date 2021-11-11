using System;

namespace Monopoly.Flyweight
{
    public abstract class Player
    {
        protected int Id;
        public string Name { get; private set; }
        public Wallet Wallet { get; private set; }
        public bool InPrison { get; set; }

        public virtual void SetExtrinsicPart(string name, Wallet wallet, bool inPrison)
        {
            Name = name;
            Wallet = wallet;
            InPrison = inPrison;
        }

        public virtual void SetWallet(Wallet wallet)
        {
            Wallet = wallet;
        }

        public virtual void SetInPrison(bool inPrison)
        {
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