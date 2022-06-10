namespace MyNamespace.Methods
{
    public class ShowEntireListOfEmployee:IMethod
    {
        private const string actionString = "Show entire list";
        public string GetActionName()
        {
            return actionString;
        }
        public void DoAction(EmployeeAPI api)
        {
            
        }
    }
}