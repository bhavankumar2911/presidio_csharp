namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoSuchEmployeeException : Exception
    {
        public NoSuchEmployeeException() : base("No employee with the id found") { }
    }
}
