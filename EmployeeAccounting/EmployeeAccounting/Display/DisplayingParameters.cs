namespace EmployeeAccounting.Display
{
    public class DisplayingParameters<T> : Display<T>
    {
        protected Dictionary<int, T>? DirEnumPos;

        public DisplayingParameters(EmployeeApi api) : base(api)
        {
        }

        protected override string? DoAction(int i, EmployeeApi api)
        {
            return DirEnumPos?[i]?.ToString();
        }

        protected override void InitDir()
        {
            DirEnumPos = new Dictionary<int, T>();
            var count = 0;
            var enumValues = Enum.GetValues(typeof(T));
            foreach (var item in enumValues) DirEnumPos.Add(count++, (T) item);
        }

        protected override void InitList()
        {
            if (DirEnumPos != null)
                foreach (var item in DirEnumPos)
                    List.Add(item.Value?.ToString());
        }
    }
}