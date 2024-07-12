namespace BankingApp.Exceptions
{
    public class LimitExceededException : Exception
    {
        public string msg="";
        public LimitExceededException(string message)
        {
            msg = message;
        }

        public override string Message => msg;
    }
}
