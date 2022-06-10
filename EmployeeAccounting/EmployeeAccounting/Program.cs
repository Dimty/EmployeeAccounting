using System;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyNamespace
{
    static class Program
    {
        public static void Main(string[] args)
        {
            EmployeeAPI employeeApi = new EmployeeAPI();
            employeeApi.Add("AAA AAA AAA","12.08.99",Gender.Male,Position.Director,"Top man");
            employeeApi.Add("BBB BBB BBB","12.08.99",Gender.Male,Position.Director,"Top man");
            employeeApi.Add("CCC CCC CCC","12.08.99",Gender.Male,Position.Director,"Top man");
            employeeApi.Add("DDD DDD DDD","12.08.99",Gender.Male,Position.Director,"Top man");
            employeeApi.Add("EEE EEE EEE","12.08.99",Gender.Male,Position.Director,"Top man");
            DisplayMainPage displayMainPage = new DisplayMainPage(employeeApi);
            displayMainPage.DisplayPage();

        }

        public static void Add()
        {
            Console.WriteLine("add");
        }
        public static void Remove()
        {
            Console.WriteLine("Remove");
        }public static void Search()
        {
            Console.WriteLine("Search");
        }
        
        private static void Size(int w, int h)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
                        
            //Size(12,12,token);
            Thread.Sleep(10000);
            //source.Cancel();
            int defW = w;
            int defH = h;
            Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    if (defH > Console.WindowHeight)
                    {
                        Console.WindowHeight = defH;
                        Console.WriteLine("CheckH");
                    }
                    if (defW > Console.WindowWidth)
                    {
                        Console.WindowWidth = defW;
                        Console.WriteLine("CheckW");
                    }
                    
                }
            });
        }
    }
}


#region Useful
/*
 
            
            
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
 */

#endregion

