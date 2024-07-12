namespace BankingApp.Exceptions
{
    public class EmptyListException : Exception
    {
        string message;
        public EmptyListException(string msg)
        {
            message = msg;
        }

        public override string Message => message;

    }
}
