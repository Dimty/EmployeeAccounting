using EmployeeAccounting.Positions;

namespace EmployeeAccounting
{
    public static class ContainerPositions
    {
        public static IPosition PosDirector()
        {
            return new Director();
        }

        public static IPosition PosDepHead()
        {
            return new DepHead();
        }

        public static IPosition PosController()
        {
            return new Controller();
        }

        public static IPosition PosWorker()
        {
            return new Worker();
        }
    }
}