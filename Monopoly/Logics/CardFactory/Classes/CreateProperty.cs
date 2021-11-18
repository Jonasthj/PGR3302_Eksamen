using System;
using Monopoly.Logics.CardFactory.Abstract;
using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.CardFactory.Classes
{
    public class CreateProperty : CreateSquare
    {
        #region Fields

        private readonly int _id;
        private readonly string _name;
        private readonly ConsoleColor _color;
        private readonly int _buyPrice;
        private readonly int _rentPrice;

        #endregion
        
        public CreateProperty(int id, string name, ConsoleColor color, int buyPrice, int rentPrice)
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