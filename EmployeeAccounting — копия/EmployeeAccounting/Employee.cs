namespace MyNamespace
{
    public class Employee
    {
        protected int id;
        protected string fullName;
        protected DateTime birthDay;
        protected bool gender;
        protected string uniqueData;
        protected Post _post;

        public Employee(int id, string fullName, DateTime birthDay, bool gender, string uniqueData)
        {
            this.id = id;
            this.fullName = fullName;
            this.birthDay = birthDay;
            this.gender = gender;
            this.uniqueData = uniqueData;
        }

        public virtual int GetId()
        {
            return id;
        }

        public virtual string GetFullName()
        {
            return fullName;
        }

        public virtual DateTime GetBirthDay()
        {
            return birthDay;
        }

        public virtual bool GetGender()
        {
            return gender;
        }

        public virtual string GetUniqueData()
        {
            return uniqueData;
        }

        public virtual Post GetPost()
        {
            return _post;
        }

        public void ChangeData(Employee employee)
        {
            this.id = employee.id;
            this.fullName = employee.fullName;
            this.birthDay = employee.birthDay;
            this.gender = employee.gender;
            this.uniqueData = employee.uniqueData;
        }

    }

    
}