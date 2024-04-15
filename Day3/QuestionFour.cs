namespace ProblemFour
{
    internal class QuestionFour
    {
        static int GetStringLength (string s)
        {
            return s.Length;
        }

        static int GetStringLengthWithoutWhitespaces(string s)
        {
            return s.Replace(" ", "").Length;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"You're name has {GetStringLength(name)} characters with whitespaces.");
            Console.WriteLine($"You're name has {GetStringLengthWithoutWhitespaces(name)} characters without whitespaces.");
        }
    }
}
