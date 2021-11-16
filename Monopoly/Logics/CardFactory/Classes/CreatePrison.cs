using Monopoly.Factory.Abstract;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class CreatePrison : CreateSquare
    {
        #region Fields
        
        private readonly int _id;
        private readonly string _name;
        
        #endregion

        #region Constructor
        
        public CreatePrison(int id, string name)
        {
            _id = id;
            _name = name;
        }
        
        #endregion

        #region Overrides
        
        public override ISquare BuildSquare()
        {
            return new Prison();
        }

        #endregion
        
    }
}