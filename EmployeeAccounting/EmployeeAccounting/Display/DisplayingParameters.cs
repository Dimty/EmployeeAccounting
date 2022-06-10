namespace MyNamespace
{
    public class DisplayingParameters<T>:Display<T>
    {
        protected Dictionary<int, T> _dirEnumPos;
        public DisplayingParameters(EmployeeAPI api) : base(api)
        {
            
        }
        
        public override string DoAction(int i, EmployeeAPI api)
        {
            return _dirEnumPos[i].ToString();
        }
        protected override void InitDir()
        {
            _dirEnumPos = new Dictionary<int, T>();
            int count = 0;
            var enumValues = Enum.GetValues(typeof(T));
            foreach (var item in enumValues)
            {
                _dirEnumPos.Add(count++,(T)item);
            }

        }

        public override void InitList()
        {
            foreach (var item in _dirEnumPos)
            {
                _list.Add(item.Value.ToString());
            }
        }
    }
}