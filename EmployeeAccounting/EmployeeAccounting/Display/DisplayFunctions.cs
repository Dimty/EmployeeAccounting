using EmployeeAccounting.Methods;

namespace EmployeeAccounting.Display
{
    public abstract class DisplayFunctions : Display<IMethod>
    {
        protected Dictionary<int, IMethod> DirAction;

        protected DisplayFunctions(EmployeeApi api) : base(api)
        {
        }

        protected override string? DoAction(int i, EmployeeApi api)
        {
            //ClearScreen();
            DirAction[i].DoAction(Api);
            return null;
        }
    }
}