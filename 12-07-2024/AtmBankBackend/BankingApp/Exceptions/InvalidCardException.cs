namespace BankingApp.Exceptions
{
    public class InvalidCardException : Exception
    {
        public string msg = "";
        public InvalidCardException()
        {
            msg = "Your card is not valid!";
        }

        public override string Message => msg;
    }
}
