using Monopoly.Logics.Objects;

namespace Monopoly.Logics.PlayerFlyweight.Abstract
{
    /// <summary>
    /// The Abstract player class that all players inherit from.
    /// </summary>
    public abstract class Player
    {
        #region Properties
        
        public int Id { get; protected init; }
        public string Name { get; private set; }
        public Wallet Wallet { get; private set; }
        public bool InPrison { get; private set; }
        
        #endregion
        
        #region Methods

        public void SetExtrinsicPart(string name, Wallet wallet, bool inPrison)
        {
            // Get's default name (easter egg).
            if(name.Length > 0)
                Name = name;
            
            Wallet = wallet;
            InPrison = inPrison;
        }

        public void AddWallet(int value)
        {
            Wallet += value;
        }

        protected void SetName(string name)
        {
            Name = name;
        }

        public void SubtractWallet(int value)
        {
            Wallet -= value;
        }

        public void SetWallet(int value)
        {
            Wallet = new Wallet(value);
        }

        public void SetInPrison(bool inPrison)
        {
            InPrison = inPrison;
        }

        #endregion
        
        public override string ToString()
        {
            return $"   Player {Id}: {Name} \n"
                +  $"   Wallet: {Wallet.Balance}M";
        }
    }
}