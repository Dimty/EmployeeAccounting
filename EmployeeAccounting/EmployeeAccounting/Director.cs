namespace MyNamespace
{
    public class Director:Employee
    {
        
        public Director(int id, string fullName, DateTime birthDay, bool gender, string uniqueData) : base(id, fullName, birthDay, gender, uniqueData)
        {
            _post = Post.Director;
        }
    }
}