namespace MyNamespace
{
    [Serializable]
    public class Employee
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public DateTime BirthDay { get; private set; }

        public Gender Gender { get; private set; }

        //private bool _gender; <-i think its better than this ↑
        public IPosition Position { get; private set; }

        public Dictionary<Position, IPosition> dictPos;
        public Employee(int id, string fullName, DateTime birthDay, Gender gender, IPosition position,
            string? addInfo = null)
        {
            Id = id;
            FullName = fullName;
            BirthDay = birthDay;
            Gender = gender;
            Position = position;
            Position.AddInfo = addInfo;
            InitDict();
        }

        private void InitDict()
        {
            
        }

        public void ChangeId(int id)
        {
            this.Id = id;
        }

        public void ChangeName(string name)
        {
            this.FullName = name;
        }

        public void ChangeDate(DateTime date)
        {
            this.BirthDay = date;
        }

        public void ChangePosition(IPosition position)
        {
            this.Position = position;
        }

        public void ChangePositionWithData(IPosition position, string data)
        {
            this.Position = position;
            this.Position.AddInfo = data;
        }
        public void ChangeAddInfo(string info)
        {
            this.Position.AddInfo = info;
        }
        
    }
}