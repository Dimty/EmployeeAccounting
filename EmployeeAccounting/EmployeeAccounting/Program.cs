using EmployeeAccounting.Display;
using EmployeeAccounting.EmployeeDir;
using EmployeeAccounting.Enums;

namespace EmployeeAccounting
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Movement: \"↑\",\"↓\",\"Enter\",q-exit");
            var employeeApi = new EmployeeApi();

            employeeApi.Add("AAA AAA AAA", "01.01.2001", Gender.Male, Position.Director, "The Best");
            employeeApi.Add("BBB BBB BBB", "02.02.2002", Gender.Female, Position.DepHead, "OOO DOMSTROY");
            employeeApi.Add("CCC CCC CCC", "03.03.2003", Gender.Male, Position.Controller, "ticket");
            employeeApi.Add("DDD DDD DDD", "04.04.2004", Gender.Female, Position.Director, "The Best");
            employeeApi.Add("EEE EEE EEE", "05.05.2005", Gender.Male, Position.Worker, "AAA AAA AAA");

            var displayMainPage = new DisplayMainPage(employeeApi);
            displayMainPage.DisplayPage();
            Console.CursorVisible = true;
        }

    }
}