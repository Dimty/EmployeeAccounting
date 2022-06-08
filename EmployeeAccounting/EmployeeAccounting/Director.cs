namespace MyNamespace
{
    public class Director:IPosition
    {
        public string AddInfo { get; set; }
        
        public Position GetPosition()
        {
            return Position.Director;
        }
    }
}