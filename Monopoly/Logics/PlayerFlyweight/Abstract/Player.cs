using Monopoly.Flyweight;

namespace Monopoly.Logics.PlayerFlyweight.Abstract
{
    /// <summary>
    /// The Abstract player class that all players inherit from.
    /// </summary>
    public abstract class Player
    {
        protected int Id;
        public string Name { get; private set; }
        public Wallet Wallet { get; private set; }
        public bool InPrison { get; set; }

        /// <description>
        /// // Setting the extrinsic part of the player objects.
        /// </description>
         
        public virtual void SetExtrinsicPart(string name, Wallet wallet, bool inPrison)
        {
            Name = name;
            Wallet = wallet;
            InPrison = inPrison;
        }

        public void AddWallet(int value)
        {
            Wallet += value;
        }
        
        public void SubtractWallet(int value)
        {
            Wallet -= value;
        }

        public virtual void SetInPrison(bool inPrison)
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