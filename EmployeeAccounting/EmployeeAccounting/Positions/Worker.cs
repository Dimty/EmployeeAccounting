namespace MyNamespace
{
    public class Worker:IPosition
    {
        public string? AddInfo { get; set; }
        public Position GetPosition()
        {
            return Position.Worker;
        }
        public override string ToString()
        {
            return "Worker";
        }
    }
}