using System;
using System.Drawing;

namespace Monopoly.UI
{
    public static class ConsoleOutput
    {
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