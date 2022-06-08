using System;

namespace MyNamespace
{
    static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Choose your destiny:");

            int top = Console.CursorTop;
            int y = top;

            Console.WriteLine("One");
            Console.WriteLine("Two");
            Console.WriteLine("Three");

            int down = Console.CursorTop;

            Console.CursorSize = 100;
            Console.CursorTop = top;

            ConsoleKey key;
            while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
            {
                if (key == ConsoleKey.UpArrow)
                {
                    if (y > top)
                    {
                        y--;
                        Console.CursorTop = y;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (y < down - 1)
                    {
                        y++;
                        Console.CursorTop = y;
                    }
                }
            }

            Console.CursorTop = down;

            if (y == top)
                Console.WriteLine("один");
            else if (y == top + 1)
                Console.WriteLine("два");
            else if (y == top + 2)
                Console.WriteLine("три");
        }
    }
}