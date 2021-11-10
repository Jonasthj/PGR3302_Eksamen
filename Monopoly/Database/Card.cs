using System;
using System.Drawing;

namespace Monopoly.Database
{
    public class Card
    { 
        public int _id { get; set; }
        public string _name { get; set; }
        public Color _color { get; set; }
        public int _purchase { get; set; }
        public int _rent { get; set; }

        public Card(int id, string name, Color color, int purchase, int rent)
        {
            _id = id;
            _name = name;
            _color = color;
            _purchase = purchase;
            _rent = rent;
        }

        public override string ToString()
        {
            return $"Card {_id}: name = '{_name}', color = '{_color}', purchase = '{_purchase}', rent = '{_rent}'";
        }
    }
}