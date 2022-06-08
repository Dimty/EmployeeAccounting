namespace MyNamespace
{
    public class Worker:Employee
    {
        
        public Worker(int id, string fullName, DateTime birthDay, bool gender, string uniqueData) : base(id, fullName, birthDay, gender, uniqueData)
        {
            _post = Post.Worker;
        }
    }
}