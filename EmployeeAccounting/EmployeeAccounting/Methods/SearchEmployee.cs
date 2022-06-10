using EmployeeAccounting.Display;
using EmployeeAccounting.EmployeeDir;
using EmployeeAccounting.Enums;

namespace EmployeeAccounting.Methods
{
    public class SearchEmployee : IMethod
    {
        private const string ActionString = "Search";

        public string GetActionName()
        {
            return ActionString;
        }

        public void DoAction(EmployeeApi api)
        {
            Console.WriteLine();
            Console.WriteLine("Do you want to enter the name of the employee's POSITION or leave the field empty? y/n");
            Console.CursorLeft = 0;
            var valueOfPos = -1;
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.CursorLeft = 0;
                var position = new DisplayingParameters<Position>(api);
                position.DisplayPage();
                var pos = position.GetUserSelection();
                Enum.TryParse(pos, out Position p);
                valueOfPos = (int) p;
            }

            Console.CursorLeft = 0;

            Console.WriteLine("Enter the name of the employee's DEPARTMENT or leave the field empty.");
            var dep = Console.ReadLine();
            dep = dep == "" ? null : dep;
            var res = api.Search(valueOfPos, dep);
            Console.WriteLine();
            if (res?.Count != 0)
                foreach (var item in res)
                {
                    var output = api.GetEmployeeString(item.Id);
                    Console.WriteLine(output);
                }
            else
                Console.WriteLine("0 matches found");

            Console.WriteLine();
        }
    }
}