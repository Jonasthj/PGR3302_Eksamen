using System.Drawing;

namespace Monopoly.Database
{
    public abstract class Card
    { 
        public int _id { get; set; }
        public string _name { get; set; }
        public Color _color { get; set; }
        
        void CreateCard()
        {
        }
    }
}