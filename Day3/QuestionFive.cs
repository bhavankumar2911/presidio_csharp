namespace ProblemFive
{
    internal class QuestionFive
    {
        static string[] GetUserCredentials ()
        {
            string? username = Console.ReadLine();
            string? password = Console.ReadLine();

            while (username == null)
            {
                Console.WriteLine("Enter username to continue");
                username = Console.ReadLine();
            }

            while (password == null)
            {
                Console.WriteLine("Enter password to continue");
                password = Console.ReadLine();
            }

            return [username, password];
        }

        static void LoginUser(int attemptsLeft)
        {
            string[] credentials = GetUserCredentials();

            string username = credentials[0];
            string password = credentials[1];

            if (username == "ABC" && password == "123")
            {
                Console.WriteLine("Welcome!");
                return;
            }

            if (attemptsLeft == 1)
            {
                Console.WriteLine("Your attempts have expired. Try again later!");
                return;
            }

            Console.WriteLine($"Wrong credentials!! You have only {--attemptsLeft} attempts left");
            LoginUser(attemptsLeft);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Kindly enter your name followed by password:");
            LoginUser(3);
        }
    }
}
