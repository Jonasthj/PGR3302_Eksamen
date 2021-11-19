using System;

namespace Monopoly.UI.ConsoleIO
{
    public static class ConsoleOutput
    {
        /// <summary>
        /// We use this class to "override" console.Write..., to avoid redundancy.
        /// </summary>
        
        public static void Print(string value)
        {
            Console.WriteLine("\n" + value);
            
        }
        
        public static void Print(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("\n" + value);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintNewLine()
        {
            Console.WriteLine();
        }

        public static void PrintEnter()
        {
            Print("Press enter to continue..", ConsoleColor.Cyan);
        }
    }
}