using System;

namespace Monopoly.UI.ConsoleIO
{
    public static class ConsoleInput
    {
        /// <summary>
        /// We use ConsoleInput in order to validate user input in a more controlled fashion. 
        /// </summary>

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