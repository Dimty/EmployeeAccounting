namespace MyNamespace.Methods
{
    public class SearchEmployee:IMethod
    {
        private const string actionString = "Search";
        public string GetActionName()
        {
            return actionString;
        }

        public void DoAction(EmployeeAPI api)
        {
            
        }
    }
}