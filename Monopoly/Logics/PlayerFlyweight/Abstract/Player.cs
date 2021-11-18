namespace Monopoly.Logics.PlayerFlyweight.Abstract
{
    /// <summary>
    /// The Abstract player class that all players inherit from.
    /// </summary>
    public abstract class Player
    {
        #region Properties
        
        protected int Id;
        public string Name { get; private set; }
        public Wallet Wallet { get; private set; }
        public bool InPrison { get; set; }
        
        #endregion
        
        #region Methods
        
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

        public override string ToString()
        {
            return $"   Player {Id}: {Name} \n"
                +  $"   Wallet: {Wallet.Balance}M";
        }
        
        #endregion
    }
}