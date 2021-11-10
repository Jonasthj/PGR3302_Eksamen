using System.Drawing;
using Monopoly.Factory.Abstract;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class CreateProperty : CreateSquare
    {
        private int _id;
        private string _name;
        private Color _color;
        private int _buyPrice;
        private int _rentPrice;

        public CreateProperty(int id, string name, Color color, int buyPrice, int rentPrice)
        {
            _id = id;
            _name = name;
            _color = color;
            _buyPrice = buyPrice;
            _rentPrice = rentPrice;
        }
        
        public override ISquare BuildSquare()
        {
            return new Property(_id, _name, _color, _buyPrice, _rentPrice);
        }
    }
}