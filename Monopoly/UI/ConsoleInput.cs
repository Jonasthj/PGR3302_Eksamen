using System;

namespace Monopoly.UI
{
    public static class ConsoleInput
    {
        public static string ReadString()
        {
            return Console.ReadLine();
        }

        public static ConsoleKey ReadKey()
        {
            return Console.ReadKey().Key;
        }

        public static int ReadInt()
        {
            string input = Console.ReadLine();
            int number;
            // Make sure the user types in a number.
            Int32.TryParse(input, out number);
            
            return number;
        }
    }
}