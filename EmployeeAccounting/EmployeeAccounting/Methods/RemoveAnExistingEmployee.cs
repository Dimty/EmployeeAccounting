using EmployeeAccounting.EmployeeDir;

namespace EmployeeAccounting.Methods
{
    public class RemoveAnExistingEmployee : IMethod
    {
        private const string ActionString = "Remove";

        public string GetActionName()
        {
            return ActionString;
        }

        public void DoAction(EmployeeApi api)
        {
            Console.WriteLine();
            Console.WriteLine("Enter the ID of the employee you want to delete");
            if (!int.TryParse(Console.ReadLine(), out var res))
            {
                Console.WriteLine("EXCEPTION: invalid value");
                return;
            }

            if (api.IdValidation(res))
            {
                Console.WriteLine();
                Console.WriteLine("Do you really want to delete this record? y/n");
                Console.WriteLine(api.GetEmployeeString(res));
                while (true)
                {
                    ConsoleKey sel;
                    if ((sel = Console.ReadKey().Key) == ConsoleKey.Y)
                    {
                        api.Remove(res);
                        break;
                    }

                    if (sel == ConsoleKey.N) break;
                    Console.CursorLeft = 0;
                    Console.WriteLine("Invalid value");
                }
            }
            else
            {
                Console.WriteLine("There is no such employee");
            }

            Console.WriteLine();
        }
    }
}