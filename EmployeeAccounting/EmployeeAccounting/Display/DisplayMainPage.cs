using EmployeeAccounting.Methods;

namespace EmployeeAccounting.Display
{
    public class DisplayMainPage : DisplayFunctions
    {
        public DisplayMainPage(EmployeeApi api) : base(api)
        {
        }

        protected override void InitDir()
        {
            DirAction = new Dictionary<int, IMethod>
            {
                {0, new ShowEntireListOfEmployee()},
                {1, new AddNewEmployee()},
                {2, new RemoveAnExistingEmployee()},
                {3, new ChangeEmployeeData()},
                {4, new SearchEmployee()}
            };
        }

        protected override void InitList()
        {
            foreach (var item in DirAction) List.Add(item.Value.GetActionName());
        }
    }
}