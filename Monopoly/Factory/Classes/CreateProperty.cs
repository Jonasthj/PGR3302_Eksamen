using System.Drawing;
using Monopoly.Factory.Abstract;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class CreateProperty : CreateSquare
    {
        #region Fields

        private readonly int _id;
        private readonly string _name;
        private readonly Color _color;
        private readonly int _buyPrice;
        private readonly int _rentPrice;

        #endregion

        #region Constructor

        public CreateProperty(int id, string name, Color color, int buyPrice, int rentPrice)
        {
            _id = id;
            _name = name;
            _color = color;
            _buyPrice = buyPrice;
            _rentPrice = rentPrice;
        }

        #endregion

        #region Overrides

        public override ISquare BuildSquare()
        {
            return new Property(_id, _name, _color, _buyPrice, _rentPrice);
        }

        #endregion
        
    }
}