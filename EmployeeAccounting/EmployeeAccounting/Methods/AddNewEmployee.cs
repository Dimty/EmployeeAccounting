namespace MyNamespace.Methods
{
    public class AddNewEmployee:IMethod
    {
        private const string actionString = "Add new employee";
        public string GetActionName()
        {
            return actionString;
        }

        public void DoAction(EmployeeAPI api)
        {
            DisplayingParameters<Gender> displayingGender = new DisplayTheAddPage<Gender>(api);
            DisplayingParameters<Position> displayingPosition = new DisplayTheAddPage<Position>(api);

            Console.WriteLine("Enter the info of the new employee");
            
            Console.Write("Full name:");
            string name=   Console.ReadLine();
            
            Console.Write("BirthDay");
            DateTime.TryParse(Console.ReadLine(),out DateTime bd);   
            
            Console.Write(" Gender:");
            displayingGender.DisplayPage();
            Gender.TryParse(displayingGender.GetUserSelection(),out Gender gender);
            
            Console.Write("Position:");
            displayingPosition.DisplayPage();
            Position.TryParse(displayingPosition.GetUserSelection(),out Position position);
            
            Console.Write("Add info:");
            string info=   Console.ReadLine();

            api.Add(name, bd, gender, position, info);
        }
    }
}