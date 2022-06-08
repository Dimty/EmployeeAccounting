namespace MyNamespace
{
    public class Employee
    {
        private int _id;
        private string _fullName;
        private DateTime _birthDay;
        private bool _gender;
        private IPosition _position;
        
        public Employee(int id, string fullName, DateTime birthDay, bool gender, IPosition position)
        {
            _id = id;
            _fullName = fullName;
            _birthDay = birthDay;
            _gender = gender;
            _position = position;
        }
            
    }

    
}