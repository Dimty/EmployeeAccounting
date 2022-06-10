using EmployeeAccounting.EmployeeDir;

namespace EmployeeAccounting.Methods
{
    public interface IMethod
    {
        string GetActionName();
        void DoAction(EmployeeApi api);
    }
}