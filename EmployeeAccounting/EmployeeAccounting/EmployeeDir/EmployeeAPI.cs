using EmployeeAccounting.Positions;

namespace EmployeeAccounting.EmployeeDir
{
    public class EmployeeApi
    {
        private readonly List<Employee?> _listOfEmployees;
        private Dictionary<Position, Func<IPosition>> _listOfPosition;

        public EmployeeApi()
        {
            _listOfPosition = new Dictionary<Position, Func<IPosition>>();
            _listOfEmployees = new List<Employee?>();
            InitPosition();
        }

        private void InitPosition()
        {
            _listOfPosition = new Dictionary<Position, Func<IPosition>>
            {
                {Position.Director, ContainerPositions.PosDirector},
                {Position.DepHead, ContainerPositions.PosDepHead},
                {Position.Controller, ContainerPositions.PosController},
                {Position.Worker, ContainerPositions.PosWorker}
            };
        }

        

        public string? GetEmployeeString(int id)
        {
            if (id > _listOfEmployees.Count || id < 0) return null;
            return
                $"{_listOfEmployees[id]!.Id} " +
                $"{_listOfEmployees[id]?.FullName}" +
                $" {_listOfEmployees[id]!.BirthDay}" +
                $" {_listOfEmployees[id]!.Gender}  " +
                $"{_listOfEmployees[id]?.Position} " +
                $"{_listOfEmployees[id]?.Position.AddInfo}";
        }

        public Employee? GetEmployeeEntity(int id)
        {
            if (id > _listOfEmployees.Count || id < 0) return null;
            return _listOfEmployees[id];
        }

        public bool IdValidation(int id)
        {
            if (id < _listOfEmployees.Count && id >= 0) return true;
            return false;
        }

        public List<Employee?> GetFullList()
        {
            return _listOfEmployees;
        }

        public void Add(string? fullName, DateTime date, Gender gender, Position position, string? addInfo)
        {
            _listOfEmployees.Add(
                new Employee(_listOfEmployees.Count, fullName, date, gender, _listOfPosition[position].Invoke(),
                    addInfo)
            );
        }

        public void Add(string? fullName, string date, Gender gender, Position position, string? addInfo)
        {
            if (!DateTime.TryParse(date, out var res)) res = DateTime.MinValue;
            _listOfEmployees.Add(
                new Employee(_listOfEmployees.Count, fullName, res, gender, _listOfPosition[position].Invoke(), addInfo)
            );
        }

        public void ChangePosition(Position position, int id)
        {
            var oldInfo = _listOfEmployees[id]?.Position.AddInfo;
            _listOfEmployees[id]?.ChangePosition(_listOfPosition[position].Invoke());
            _listOfEmployees[id]?.ChangeAddInfo(oldInfo);
        }

        public void Remove(int id)
        {
            _listOfEmployees[id] = _listOfEmployees.Last();
            _listOfEmployees[id]?.ChangeId(id);
            _listOfEmployees.RemoveAt(_listOfEmployees.Count - 1);
        }

        public void ChangeEmployee(Employee? employee)
        {
            if (employee != null) _listOfEmployees[employee.Id] = employee;
        }

        public List<Employee>? Search(int pos, string? branch)
        {
            var list = new List<Employee>();

            if (pos == -1 && branch == null) return list;
            if (pos == -1) return SearchBranch(branch);
            if (branch == null) return SearchPos(pos);
            return FullSearch(pos, branch);
        }

        private List<Employee>? SearchPos(int pos)
        {
            var list = new List<Employee?>();

            foreach (var employee in _listOfEmployees)
                if (employee != null && employee.Position.GetPosition() == (Position) pos)
                    list.Add(employee);

            return list;
        }

        private List<Employee>? SearchBranch(string? branch)
        {
            var list = new List<Employee?>();

            foreach (var employee in _listOfEmployees)
                if (employee?.Position.AddInfo == branch)
                    list.Add(employee);

            return list;
        }

        private List<Employee>? FullSearch(int pos, string branch)
        {
            var list = new List<Employee?>();

            foreach (var employee in _listOfEmployees)
                if (employee.Position.GetPosition() == (Position) pos &&
                    employee.Position.AddInfo == branch)
                    list.Add(employee);

            return list;
        }
    }
}