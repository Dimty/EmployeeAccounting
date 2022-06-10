namespace MyNamespace.Methods
{
    public class ShowEntireListOfEmployee:IMethod
    {
        private const string actionString = "Show entire list";
        public string GetActionName()
        {
            return actionString;
        }
        public void DoAction(EmployeeAPI api)
        {
            Console.WriteLine();
            var list = api.GetFullList();
            foreach (var item in list)
            {
                string res = string.Empty;
                res += item.Id + " " +
                       item.FullName + " " +
                       item.BirthDay.ToString("d") + " " +
                       item.Gender + " " +
                       item.Position + " " +
                       item.Position.AddInfo;
                Console.WriteLine(res);
            }
            Console.WriteLine();
        }
    }
}