using EmployeeAccounting.Positions;

namespace EmployeeAccounting.EmployeeDir
{
    public class Employee
    {

        public Employee(int id, string? fullName, DateTime birthDay, Gender gender, IPosition position,
            string? addInfo)
        {
            Id = id;
            FullName = fullName;
            BirthDay = birthDay;
            Gender = gender;
            Position = position;
            Position.AddInfo = addInfo;
            InitDict();
        }

        public int Id { get; private set; }
        public string? FullName { get; private set; }
        public DateTime BirthDay { get; private set; }
        public Gender Gender { get; private set; }

        //private bool _gender; <-i think its better than this ↑
        public IPosition Position { get; private set; }

        private void InitDict()
        {
        }

        public void ChangeId(int id)
        {
            Id = id;
        }

        public void ChangeName(string? name)
        {
            FullName = name;
        }

        public void ChangeDate(DateTime date)
        {
            BirthDay = date;
        }

        public void ChangeGender(Gender gender)
        {
            Gender = gender;
        }

        public void ChangePosition(IPosition position)
        {
            Position = position;
        }

        public void ChangePositionWithData(IPosition position, string data)
        {
            Position = position;
            Position.AddInfo = data;
        }

        public void ChangeAddInfo(string? info)
        {
            Position.AddInfo = info;
        }
    }
}