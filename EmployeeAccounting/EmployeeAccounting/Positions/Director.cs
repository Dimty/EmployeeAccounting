using EmployeeAccounting.Enums;

namespace EmployeeAccounting.Positions
{
    public class Director : IPosition
    {
        public string? AddInfo { get; set; }

        public Position GetPosition()
        {
            return Position.Director;
        }

        public override string ToString()
        {
            return "Director";
        }
    }
}