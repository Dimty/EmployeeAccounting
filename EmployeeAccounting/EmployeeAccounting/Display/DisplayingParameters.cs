namespace MyNamespace
{
    public abstract class DisplayingParameters<T>:Display<T>
    {
        protected Dictionary<int, T> _dirEnumPos;
        public DisplayingParameters(EmployeeAPI api) : base(api)
        {
        }
        
        public override string DoAction(int i, EmployeeAPI api)
        {
            return _dirEnumPos[i].ToString();
        }
    }
}