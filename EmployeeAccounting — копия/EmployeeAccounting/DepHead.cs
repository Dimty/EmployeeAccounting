namespace MyNamespace
{
    public class DepHead:Employee
    {
        public DepHead(int id, string fullName, DateTime birthDay, bool gender, string uniqueData) : base(id, fullName, birthDay, gender, uniqueData)
        {
            _post = Post.DepHead;
        }
    }
}