namespace MyNamespace.Methods
{
    public class AddNewEmployee : IMethod
    {
        private const string actionString = "Add new employee";

        public string GetActionName()
        {
            return actionString;
        }

        public void DoAction(EmployeeAPI api)
        {
            DisplayingParameters<Gender> displayingGender = new DisplayingParameters<Gender>(api);
            DisplayingParameters<Position> displayingPosition = new DisplayingParameters<Position>(api);

            Console.WriteLine("Enter the info of the new employee");

            var name = SetName();
            var bd = SetBirthDay();
            var gender = SetGender(displayingGender);
            var position = SetPosition(displayingPosition);
            var info = SetAddInfo();

            api.Add(name, bd, gender, position, info);
        }

        private string SetAddInfo()
        {
            Console.Write("Add info:");
            return Console.ReadLine();
        }

        private Position SetPosition(DisplayingParameters<Position> displayingPosition)
        {
            Console.WriteLine("Position:");
            displayingPosition.DisplayPage();
            Position.TryParse(displayingPosition.GetUserSelection(), out Position position);
            return position;
        }

        private string SetName()
        {
            Console.Write("Full name:");
            return Console.ReadLine();
        }

        private DateTime SetBirthDay()
        {
            Console.Write("BirthDay:");
            DateTime.TryParse(Console.ReadLine(), out DateTime bd);
            return bd;
        }

        private Gender SetGender(DisplayingParameters<Gender> displayingGender)
        {
            Console.WriteLine("Gender:");
            displayingGender.DisplayPage();
            Gender.TryParse(displayingGender.GetUserSelection(), out Gender gender);
            return gender;
        }
    }
}