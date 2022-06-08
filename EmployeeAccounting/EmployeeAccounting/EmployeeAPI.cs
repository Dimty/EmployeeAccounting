namespace MyNamespace
{
    public class EmployeeAPI
    {
        private Dictionary<Position, IPosition> _listOfPosition;
        private List<Employee> _listOfEmployees;

        public EmployeeAPI()
        {
            _listOfEmployees = new List<Employee>();
            InitPosition();
        }

        private void InitPosition()
        {
            _listOfPosition = new Dictionary<Position, IPosition>()
            {
                {Position.Director, new Director()},
                {Position.DepHead, new Worker()},
                {Position.Controller, new Controller()},
                {Position.Worker, new Worker()},
            };
        }

        public Employee GetEmployee(int id)
        {
            if (id > _listOfEmployees.Count || id < 0) return null;
            return _listOfEmployees[id];
        }

        public List<Employee> GetFullList()
        {
            return _listOfEmployees;
        }

        public void Add(string fullName,DateTime date,Gender gender,IPosition position,string addInfo)
        {
            _listOfEmployees.Add(
                new Employee(_listOfEmployees.Count,fullName,date,gender,position,position.AddInfo)
                );
        }

        public string Remove(int id)
        {
            if (id >= _listOfEmployees.Count || id < 0) return "Out of range";
            _listOfEmployees[id] = _listOfEmployees.Last();
            _listOfEmployees[id].ChangeId(id);
            _listOfEmployees.RemoveAt(_listOfEmployees.Count-1);
            return "The item has been removed";
        }
        
        
        
        public List<Employee>? Search(int pos, string? branch)
        {
            List<Employee> list = new List<Employee>();

            if (pos == -1 && branch == null) return null;
            if (pos == -1) return SearchBranch(branch);
            if (branch == null) return SearchPos(pos);
            return FullSearch(pos, branch);
            return list;
        }

        private List<Employee>? SearchPos(int pos)
        {
            var list = new List<Employee>();

            foreach (var employee in _listOfEmployees)
            {
                if (employee.Position.GetPosition() == (Position) pos)
                {
                    list.Add(employee);
                }
            }
            
            return list;
        }

        private List<Employee> SearchBranch(string branch)
        {
            var list = new List<Employee>();
            
            foreach (var employee in _listOfEmployees)
            {
                if (employee.Position.AddInfo==branch)
                {
                    list.Add(employee);
                }
            }

            return list;
        }
        
        private List<Employee> FullSearch(int pos,string branch)
        {
            var list = new List<Employee>();
            
            foreach (var employee in _listOfEmployees)
            {
                if (employee.Position.GetPosition() == (Position)pos &&
                    employee.Position.AddInfo==branch )
                {
                    list.Add(employee);
                }
            }

            return list;
        }


        
    }
}