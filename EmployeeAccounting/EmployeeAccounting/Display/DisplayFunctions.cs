using MyNamespace.Methods;

namespace MyNamespace
{
    public abstract class DisplayFunctions:Display<IMethod>
    {
        protected Dictionary<int, IMethod> _dirAction;

        public DisplayFunctions(EmployeeAPI api) : base(api)
        {
        }
        public override string DoAction(int i, EmployeeAPI api)
        {
            _dirAction[i].DoAction(_api);
            return null;
        }
    }
}