using MyNamespace.Methods;

namespace MyNamespace
{
    public abstract class Display<T>
    {
        private Dictionary<int, T> _dir;
        protected List<string> _list;
        protected EmployeeAPI _api;
        private string? userSelection;

        public Display(EmployeeAPI api)
        {
            Console.CursorVisible = false;
            _list = new List<string>();
            _api = api;
            InitParams();
        }

        public void InitParams()
        {
            InitDir();
            InitList();
        }

        public void DisplayPage()
        {
            bool loop;
            do
            {
                //PrintManagement();
                PrintFirstOutput(out int top, out int y);
                y = SeletionFromTheMainPage(top, y, out ConsoleKey key);
                loop = SelectionAction(key, y);
            } while (loop);
        }

        protected bool SelectionAction(ConsoleKey key, int i)
        {
            if (key == ConsoleKey.Enter)
            {
                //_dir[i]?.DoAction(_api);
                userSelection = DoAction(i,_api);
                if (userSelection != null) return false;
                return true;
            }

            return false;
        }

        public void ClearScreen()
        {
            int top = Console.CursorTop;
            int down = top + _list.Count;
            Console.CursorLeft = 0;
            for (int i = 0; i <down; i++)
            {
                Console.WriteLine("{0,25}"," ");
                Console.CursorLeft = 0;
            }
            Console.CursorTop = top;
        }
        public string? GetUserSelection()
        {
            return userSelection;
        }

        public abstract string DoAction(int i,EmployeeAPI api);

        protected int SeletionFromTheMainPage(int top, int y, out ConsoleKey key)
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

            Console.CursorTop = down;
            Console.CursorLeft = 0;
            return y-top;
        }



        protected void PrintFirstOutput(out int top, out int y)
        {
            top = Console.CursorTop;
            y = top;
            Console.WriteLine("<" + _list[0] + ">");
            for (int i = 1; i < _list.Count; i++)
            {
                Console.WriteLine(_list[i]);
            }
        }

        protected void MoveCursorPosition(ref int pos, int curOffset, int offset)
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


        protected abstract void InitDir();


        public abstract void InitList();
    }
}