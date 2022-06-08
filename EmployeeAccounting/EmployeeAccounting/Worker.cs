namespace MyNamespace
{
    public class Worker:IPosition
    {
        public string AddInfo { get; set; }
        public Position GetPosition()
        {
            return Position.Worker;
        }
    }
}