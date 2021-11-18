using System;

namespace Monopoly.Logics
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