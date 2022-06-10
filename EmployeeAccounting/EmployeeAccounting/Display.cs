namespace MyNamespace
{
    public abstract class Display
    {
        protected List<string> _list;
        protected Dictionary<int, Action> _dirAction;
        protected EmployeeAPI _api;

        public Display(EmployeeAPI api)
        {
            Console.CursorVisible = false;
            _api = api;
            InitList();
            InitDir();
        }

        public void DisplayMainPage()
        {
            bool loop;
            do
            {
                //PrintManagement();
                PrintFirstOutput(out int top, out int y);
                y = SeletionFromTheMainPage(top, y,out ConsoleKey key);
                loop = SelectionAction(key,y);    
            } while (loop);
            
        }

        protected bool SelectionAction(ConsoleKey key, int i)
        {
            if (key == ConsoleKey.Enter)
            {
                _dirAction[i]?.Invoke();
                return true;
            }
            return false;

        }


        protected int SeletionFromTheMainPage(int top, int y,out ConsoleKey key)
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

        // protected void PrintManagement()
        // {
        //     Console.WriteLine("Movement in the \"↑\",\"↓\",\"Enter\"");
        // }

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


        protected abstract void InitList();
    }
}