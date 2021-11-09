using System.Drawing;

namespace Monopoly.Database
{
    public class Card1 : Card
    {
        public string _info { get; set; }

        public void CreateCard()
        {
            _id = 0;
            _name = "Start";
            _color = Color.White;
            _info = "Get 100M";
        }

        public override string ToString()
        {
            return $"id {_id}, name: {_name}, color: {_color}, info: {_info}";
        }
    }
}