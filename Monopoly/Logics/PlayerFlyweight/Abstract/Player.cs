using Monopoly.Flyweight;

namespace Monopoly.Logics.PlayerFlyweight.Abstract
{
    // 
    public abstract class Player
    {
        protected int Id;
        public string Name { get; private set; }
        public Wallet Wallet { get; private set; }
        public bool InPrison { get; private set; }

        public void SetExtrinsicPart(string name, Wallet wallet, bool inPrison)
        {
            if(name.Length > 0)
                Name = name;
            
            Wallet = wallet;
            InPrison = inPrison;
        }

        public void AddWallet(int value)
        {
            Wallet += value;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SubtractWallet(int value)
        {
            Wallet -= value;
        }

        public void SetInPrison(bool inPrison)
        {
            InPrison = inPrison;
        }

        public override string ToString()
        {
            return $"   Player {Id}: {Name} \n"
                +  $"   Wallet: {Wallet.Balance}M";
        }
    }
}