using System;

namespace Monopoly.Logics.Objects
{
    public class Dice
    {
        public static int RollDice()
        {
            var random = new Random();
            int diceNumber = random.Next(1, 7);
            return diceNumber;
        }
    }
}