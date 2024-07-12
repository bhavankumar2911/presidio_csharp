namespace BankingApp.Exceptions
{
    public class InsufficientFundsException : Exception
    {

        string message;
        public InsufficientFundsException(string element)
        {
            message = element;
        }

        public override string Message => message;
    }
}
