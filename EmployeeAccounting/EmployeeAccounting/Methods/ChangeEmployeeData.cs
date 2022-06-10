namespace MyNamespace.Methods
{
    public class ChangeEmployeeData:IMethod
    {
        private const string actionString = "Change employeer data";
        public string GetActionName()
        {
            return actionString;
        }

        public void DoAction(EmployeeAPI api)
        {
            
        }

    }
}