namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoEmployeesFoundException : Exception
    {
        public NoEmployeesFoundException() : base("No employees available") { }
    }
}
