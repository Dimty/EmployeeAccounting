namespace MyNamespace.Methods
{
    public class RemoveAnExistingEmployee:IMethod
    {
        private const string actionString = "Remove";
        public string GetActionName()
        {
            return actionString;
        }

        public void DoAction(EmployeeAPI api)
        {
            
        }
    }
}