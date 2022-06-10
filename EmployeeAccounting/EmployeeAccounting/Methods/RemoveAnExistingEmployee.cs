namespace MyNamespace.Methods
{
    public class RemoveAnExistingEmployee:IMethod
    {
        private const string actionString = "Remove";
        public string GetActionName()
        {
            return actionString;
        }

        public void DoAction(EmployeeAPI api)
        {
            Console.WriteLine();
            Console.WriteLine("Enter the ID of the employee you want to delete");
            if (!int.TryParse(Console.ReadLine(), out int res))
            {
                Console.WriteLine("EXCEPTION: invalid value");
                return;
            }

            if (api.IdValidation(res))
            {
                Console.WriteLine();
                Console.WriteLine("Do you really want to delete this record? y/n");
                Console.WriteLine(api.GetEmployeeString(res));
                ConsoleKey sel;
                while (true)
                {
                    if ((sel = Console.ReadKey().Key) == ConsoleKey.Y)
                    {
                        api.Remove(res);
                        break;
                    }
                    else
                    {
                        if (sel == ConsoleKey.N)
                        {
                            break;
                            ;
                        }

                        Console.WriteLine("Invalid value");
                    }
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