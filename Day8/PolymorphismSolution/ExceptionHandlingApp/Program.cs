namespace ExceptionHandlingApp
{
    internal class Program
    {
        static double DivideNumbers (double num1, double num2)
        {
            try
            {
                return num1 / num2; 
            } catch (DivideByZeroException dbze)
            {
                Console.WriteLine("Cannot divide by zero");
            } 
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
