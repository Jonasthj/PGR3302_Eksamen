using Monopoly.Factory.Abstract;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class CreateChance : CreateSquare
    {
        #region Fields
        
        private readonly int _id;
        private readonly string _name;
        private readonly string _description;
        
        #endregion

        #region Constructor
        
        public CreateChance(int id, string name, string description)
        {
            _id = id;
            _name = name;
            _description = description;
        }
        
        #endregion

        #region Overrides
        
        public override ISquare BuildSquare()
        {
            return new Chance(_id, _name, _description);
        }
        
        #endregion
    }
}