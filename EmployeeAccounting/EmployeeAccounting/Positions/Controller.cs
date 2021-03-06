using EmployeeAccounting.Enums;

namespace EmployeeAccounting.Positions
{
    public class Controller : IPosition
    {
        public string? AddInfo { get; set; }

        public Position GetPosition()
        {
            return Position.Controller;
        }

        public override string ToString()
        {
            return "Controller";
        }
    }
}