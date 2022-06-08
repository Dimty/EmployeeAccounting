namespace MyNamespace
{
    public class DepHead:IPosition
    {
        public string? AddInfo { get; set; }
        public Position GetPosition()
        {
            return Position.DepHead;
        }
        public override string ToString()
        {
            return "DepHead";
        }
    }
}