namespace EmployeeAccounting.Display
{
    public abstract class Display<T>
    {
        protected readonly EmployeeApi Api;
        protected readonly List<string> List;
        private string? _userSelection;

        protected Display(EmployeeApi api)
        {
            Console.CursorVisible = false;
            List = new List<string>();
            Api = api;
            InitParams();
        }


        public void DisplayPage()
        {
            bool loop;
            do
            {
                PrintFirstOutput(out var top, out var y);
                y = SelectionFromTheMainPage(top, y, out var key);
                loop = SelectionAction(key, y);
            } while (loop);
        }

        private bool SelectionAction(ConsoleKey key, int i)
        {
            if (key != ConsoleKey.Enter) return false;
            _userSelection = DoAction(i, Api);
            if (_userSelection != null) return false;
            return true;
        }

        protected void ClearScreen()
        {
            var top = Console.CursorTop;
            var down = top + List.Count;
            Console.CursorLeft = 0;
            for (var i = 0; i < down; i++)
            {
                Console.WriteLine("{0,25}", " ");
                Console.CursorLeft = 0;
            }

            Console.CursorTop = top;
        }

        public string? GetUserSelection()
        {
            return _userSelection;
        }


        private int SelectionFromTheMainPage(int top, int y, out ConsoleKey key)
        {
            var down = Console.CursorTop;
            Console.CursorTop = top;
            while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
            {
                if (key == ConsoleKey.Q) break;

                if (key == ConsoleKey.UpArrow)
                {
                    if (y > top) MoveCursorPosition(ref y, top, -1);
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (y < down - 1) MoveCursorPosition(ref y, top, 1);
                }
            }

            Console.CursorTop = down;
            Console.CursorLeft = 0;
            return y - top;
        }


        private void PrintFirstOutput(out int top, out int y)
        {
            top = Console.CursorTop;
            y = top;
            Console.WriteLine("<" + List[0] + ">");
            for (var i = 1; i < List.Count; i++) Console.WriteLine(List[i]);
        }

        private void MoveCursorPosition(ref int pos, int curOffset, int offset)
        {
            Console.CursorLeft = 0;
            Console.Write("{0,25}", " ");
            Console.CursorLeft = 0;
            Console.Write(List[pos - curOffset]);
            pos += offset;
            Console.CursorTop = pos;
            Console.Write("{0,25}", " ");
            Console.CursorLeft = 0;
            Console.Write("<" + List[pos - curOffset] + ">");
        }

        private void InitParams()
        {
            InitDir();
            InitList();
        }

        protected abstract void InitDir();
        protected abstract void InitList();
        protected abstract string? DoAction(int i, EmployeeApi api);
    }
}