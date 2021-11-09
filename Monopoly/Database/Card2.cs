using System.Drawing;

namespace Monopoly.Database
{
    public class Card2 : Card
    {
        private int _purchase { get; set; }
        private int _rent { get; set; }
        public void CreateCard()
        {
            _id = 1;
            _name = "Grensen";
            _color = Color.Brown;
            _purchase = 100;
            _rent = 30;
        }
    }
}