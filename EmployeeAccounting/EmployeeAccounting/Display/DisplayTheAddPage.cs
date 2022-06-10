namespace MyNamespace
{
    public class DisplayTheAddPage<T>:DisplayingParameters<T> where T: Enum
    {
        public DisplayTheAddPage(EmployeeAPI api) : base(api)
        {
        }

        protected override void InitDir()
        {
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