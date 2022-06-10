namespace MyNamespace.Methods
{
    public class SearchEmployee:IMethod
    {
        private const string actionString = "Search";
        public string GetActionName()
        {
            return actionString;
        }

        public void DoAction(EmployeeAPI api)
        {
            Console.WriteLine();
            Console.WriteLine("Do you want to enter the name of the employee's POSITION or leave the field empty? y/n");
            Console.CursorLeft = 0;
            int valueOfPos = -1;
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.CursorLeft = 0;
                DisplayingParameters<Position> position = new DisplayingParameters<Position>(api);
                position.DisplayPage();
                string pos = position.GetUserSelection();
                Enum.TryParse(pos, out Position p);
                valueOfPos = (int)p;
            }

            
            Console.WriteLine("Enter the name of the employee's DEPARTMENT or leave the field empty.");
            var dep = Console.ReadLine();
            dep= dep == "" ? null : dep;
            var res = api.Search(valueOfPos,dep);
            Console.WriteLine();
            foreach (var item in res)
            {
                var output =  api.GetEmployeeString(item.Id);
                Console.WriteLine(output);
            }

            Console.WriteLine();
        }
    }
}