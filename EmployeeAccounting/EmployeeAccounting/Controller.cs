namespace MyNamespace
{
    public class Controller:IPosition
    {
        public string AddInfo { get; set; }
        public Position GetPosition()
        {
            return Position.Controller;
        }
    }
}