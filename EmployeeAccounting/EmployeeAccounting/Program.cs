using System;
using System.Globalization;
using System.Text.Json;

namespace MyNamespace
{
    static class Program
    {
        public static void Main(string[] args)
        {
            EmployeeAPI employeeAPI = new EmployeeAPI();
            DateTime date = DateTime.Parse("12.08.1999");
            Console.WriteLine(date.ToString("d"));
            Console.SetWindowSize(100,20);

            Employee employee = new Employee(0, "Takoyto takoytovich", DateTime.Parse("12.08.1999"), Gender.Male,
                new Director(), "Boss of the gym");
                
            var json = JsonSerializer.Serialize(employee);
            File.WriteAllText("file.json",json);
            
        }

        private static void Size(int w, int h,CancellationToken token1)
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

