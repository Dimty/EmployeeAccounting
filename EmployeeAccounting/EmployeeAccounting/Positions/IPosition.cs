using EmployeeAccounting.Enums;

namespace EmployeeAccounting.Positions
{
    public interface IPosition
    {
        string? AddInfo { get; set; }
        Position GetPosition();
    }
}