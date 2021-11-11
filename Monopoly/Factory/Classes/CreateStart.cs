using Monopoly.Factory.Abstract;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class CreateStart : CreateSquare
    {
        #region Fields

        private int _id;
        private string _name;

        #endregion

        #region Constructors

        public CreateStart(int id, string name)
        {
            _id = id;
            _name = name;
        }
        
        #endregion

        #region Overrides

        public override ISquare BuildSquare()
        {
            return new Start(_id, _name);
        }

        #endregion
        
    }
}