using EmployeeAccounting.EmployeeDir;

namespace EmployeeAccounting.Methods
{
    public class ShowEntireListOfEmployee : IMethod
    {
        private const string ActionString = "Show entire list";

        public string GetActionName()
        {
            return ActionString;
        }

        public void DoAction(EmployeeApi api)
        {
            Console.WriteLine();
            var list = api.GetFullList();
            foreach (var item in list)
            {
                var res = string.Empty;
                res +=
                    $"{item.Id} " +
                    $"{item.FullName} " +
                    $"{item.BirthDay:d} " +
                    $"{item.Gender} " +
                    $"{item.Position} " +
                    $"{item.Position.AddInfo}";
                Console.WriteLine(res);
            }

            Console.WriteLine();
        }
    }
}