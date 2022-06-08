namespace MyNamespace
{
    public class Controller:Employee
    {
        public Controller(int id, string fullName, DateTime birthDay, bool gender, string uniqueData) : base(id, fullName, birthDay, gender, uniqueData)
        {
            _post = Post.Controller;
        }
    }
}