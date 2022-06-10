namespace MyNamespace.Methods
{
    public class ChangeEmployeeData : IMethod
    {
        private const string actionString = "Change employeer data";

        public string GetActionName()
        {
            return actionString;
        }

        public void DoAction(EmployeeAPI api)
        {
            Console.WriteLine();
            Console.WriteLine("Enter the ID of the employee you want to change");
            if (!int.TryParse(Console.ReadLine(), out int res))
            {
                Console.WriteLine("EXCEPTION: invalid value");
                return;
            }

            if (api.IdValidation(res))
            {
                Console.WriteLine();
                Console.WriteLine("Do you really want to change this record? y/n");
                Console.WriteLine(api.GetEmployeeString(res));
                ConsoleKey sel;
                while (true)
                {
                    if ((sel = Console.ReadKey().Key) == ConsoleKey.Y)
                    {
                        Console.CursorTop -=1;
                        Console.CursorLeft = 0;
                        ChangeUnion(api, res);
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

        private void ChangeUnion(EmployeeAPI api, int res)
        {
            var emp = api.GetEmployeeEntity(res);

            var newStr = string.Empty;
            if ((newStr = ChangeString("name")) != null) emp.ChangeName(newStr);
            if ((newStr = ChangeString("Birthdaty")) != null) emp.ChangeDate(DateTime.Parse(newStr));
            if ((newStr = ChangeEnum<Gender>("gender", api)) != null)
                emp.ChangeGender(Gender.Parse<Gender>(newStr));
            if ((newStr = ChangeEnum<Position>("position", api)) != null)
                api.ChangePosition(Position.Parse<Position>(newStr),
                    res); // <- жуткая вещь, но что поделать -_-
            if ((newStr = ChangeString("add info")) != null) emp.ChangeAddInfo(newStr);
        }

        private string ChangeString(string str)
        {
            Console.WriteLine();
            Console.WriteLine("Do you want to change {0} y/n", str);
            Console.CursorLeft = 0;
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.CursorLeft = 0;
                Console.Write("New {0} is:", str);

                return Console.ReadLine();
            }

            Console.CursorTop -= 1;
            return null;
        }

        private string ChangeEnum<T>(string str, EmployeeAPI api)
        {
            DisplayingParameters<T> displayingParameters = new DisplayingParameters<T>(api);
            Console.WriteLine();
            Console.WriteLine("Do you want to change {0} y/n", str);
            Console.CursorLeft = 0;
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.CursorLeft = 0;
                displayingParameters.DisplayPage();
                var res = displayingParameters.GetUserSelection();

                return res;
            }

            Console.CursorTop -= 1;

            return null;
        }
    }
}