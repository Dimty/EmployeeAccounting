namespace MyNamespace
{
    public class DisplayMainPage:Display
    {
        private FunctionClass _function;

        public DisplayMainPage(EmployeeAPI api) : base(api)
        {
            _function = new FunctionClass(api);
        }

        protected override void InitDir()
        {
            _dirAction = new Dictionary<int, Action>()
            {
                {0, _function.ShowAllList},
                {1, _function.Add},
                {2, _function.Remove},
                {3, _function.Search},
                {4, _function.Exit},
            };
        }

        protected override void InitList()
        {
            _list = new List<string>()
            {
                "Show All",
                "Add new employee",
                "Remove exist employee",
                "Search",
                "Exit"
            };
        }
    }

    public class FunctionClass
    {
        private EmployeeAPI _api;

        public FunctionClass(EmployeeAPI api)
        {
            _api = api;
        }
        public void ShowAllList()
        {
            Console.WriteLine();
            string res = string.Empty;
            foreach (var item in _api.GetFullList())
            {
                res += item.Id + " " +
                       item.FullName.Split(" ") + " " +
                       item.BirthDay + " " +
                       item.Gender + " " +
                       item.Position + " " +
                       item.Position.AddInfo;
            }
        }
        public void Add()
        {
            // Console.WriteLine("Enter the info of the new employee");
            // Console.Write("Full name:");
            // string name=   Console.ReadLine();
            // Console.Write("BirthDay:");
            // string bd=   Console.ReadLine();
            // Console.Write(" name:");
            //
            // Console.Write("Full name:");
            // string name=   Console.ReadLine();
            // Console.Write("Full name:");
            // string name=   Console.ReadLine();
            // Console.Write("Full name:");
            // string name=   Console.ReadLine();

        }

        public void Remove()
        {
            Console.WriteLine("Enter the id to remove");
            int value;
            while (!int.TryParse(Console.ReadLine(),out value))
            {
                Console.WriteLine("NoN");
            }
            _api.Remove(value);
        }

        public void Search()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}


#region Display

/*private List<string> _list;
        private Dictionary<int, Action> _dirAction;
        private readonly FunctionClass _function;
        private EmployeeAPI _api;

        public DisplayMainPage(EmployeeAPI api)
        {
            _function = new FunctionClass(api);
            _api = api;
            InitList();
            InitDir();
        }

        public void PrintMainPage(EmployeeAPI api)
        {
            bool loop;
            do
            {
                PrintManagement();
                PrintFirstOutput(out int top, out int y);
                y = SeletionFromTheMainPage(top, y,out ConsoleKey key);
                loop = SelectionAction(key,y);    
            } while (loop);
            
        }

        private bool SelectionAction(ConsoleKey key, int i)
        {
            if (key == ConsoleKey.Enter)
            {
                _dirAction[i]?.Invoke();
                return true;
            }
            return false;

        }


        private int SeletionFromTheMainPage(int top, int y,out ConsoleKey key)
        {
            int down = Console.CursorTop;
            Console.CursorTop = top;
            while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
            {
                if (key == ConsoleKey.Q)
                {
                    break;
                }

                if (key == ConsoleKey.UpArrow)
                {
                    if (y > top)
                    {
                        MoveCursorPosition(ref y, top, -1);
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (y < down - 1)
                    {
                        MoveCursorPosition(ref y, top, 1);
                    }
                }
            }

            return y;
        }

        private void PrintManagement()
        {
            Console.WriteLine("Movement in the \"↑\",\"↓\",\"Enter\"");
        }

        private void PrintFirstOutput(out int top, out int y)
        {
            top = Console.CursorTop;
            y = top;
            Console.WriteLine("<" + _list[0] + ">");
            for (int i = 1; i < _list.Count; i++)
            {
                Console.WriteLine(_list[i]);
            }
        }

        private void MoveCursorPosition(ref int pos, int curOffset, int offset)
        {
            Console.CursorLeft = 0;
            Console.Write("{0,25}", " ");
            Console.CursorLeft = 0;
            Console.Write(_list[pos - curOffset]);
            pos += offset;
            Console.CursorTop = pos;
            Console.Write("{0,25}", " ");
            Console.CursorLeft = 0;
            Console.Write("<" + _list[pos - curOffset] + ">");
        }


        private void InitDir()
        {
            _dirAction = new Dictionary<int, Action>()
            {
                {0, () => _function.ShowAllList()},
                {1, () => _function.Add()},
                {2, () => _function.Remove()},
                {3, () => _function.Search()},
            };
        }

        private void InitList()
        {
            _list = new List<string>()
            {
                "Show All",
                "Add new employee",
                "Remove exist employee",
                "Search",
                "Exit"
            };
        }
    }*/

#endregion