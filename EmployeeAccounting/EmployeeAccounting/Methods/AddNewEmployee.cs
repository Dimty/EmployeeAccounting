using EmployeeAccounting.Display;

namespace EmployeeAccounting.Methods
{
    public class AddNewEmployee : IMethod
    {
        private const string ActionString = "Add new employee";

        public string GetActionName()
        {
            return ActionString;
        }

        public void DoAction(EmployeeApi api)
        {
            var displayingGender = new DisplayingParameters<Gender>(api);
            var displayingPosition = new DisplayingParameters<Position>(api);

            Console.WriteLine("Enter the info of the new employee");

            var name = SetName();
            var bd = SetBirthDay();
            var gender = SetGender(displayingGender);
            var position = SetPosition(displayingPosition);
            var info = SetAddInfo();

            api.Add(name, bd, gender, position, info);
            Console.WriteLine();
        }

        private string? SetAddInfo()
        {
            Console.Write("Add info:");
            return Console.ReadLine();
        }

        private Position SetPosition(DisplayingParameters<Position> displayingPosition)
        {
            Console.WriteLine("Position:");
            displayingPosition.DisplayPage();
            Enum.TryParse(displayingPosition.GetUserSelection(), out Position position);
            return position;
        }

        private string? SetName()
        {
            Console.Write("Full name:");
            return Console.ReadLine();
        }

        private DateTime SetBirthDay()
        {
            Console.Write("BirthDay:");
            DateTime.TryParse(Console.ReadLine(), out var bd);
            return bd;
        }

        private Gender SetGender(DisplayingParameters<Gender> displayingGender)
        {
            Console.WriteLine("Gender:");
            displayingGender.DisplayPage();
            Enum.TryParse(displayingGender.GetUserSelection(), out Gender gender);
            return gender;
        }
    }
}