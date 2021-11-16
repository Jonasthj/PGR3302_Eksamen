using System;
using System.Drawing;

namespace Monopoly.UI
{
    public static class ConsoleOutput
    {
        public static void Print(string value)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(value);
        }
        
        public static void Print(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Print(int value)
        {
            Console.WriteLine(value.ToString());
        }

        public static void PrintNewLine()
        {
            Console.WriteLine("\n");
        }
        
        
    }
}