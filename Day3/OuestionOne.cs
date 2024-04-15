namespace FirstDayProblems
{
    internal class OuestionOne
    {
        // sum
        static double GetSum(double num1, double num2)
        {
            return (num1 + num2);
        }

        // divide first number by second
        static double GetQuotient(double num1, double num2)
        {
            return (num1 / num2);
        }

        // subtract second number from first
        static double GetDifference(double num1, double num2)
        {
            return (num1 - num2);
        }

        // get product
        static double GetProduct(double num1, double num2)
        {
            return (num1 * num2);
        }

        // get remainder
        static double GetRemainder(double num1, double num2)
        {
            return (num1 % num2);
        }

        static void RunCalculator()
        {
            double num1;

            Console.WriteLine("Enter first number: ");
            while (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Invalid number. Enter again: ");
            }

            double num2;

            Console.WriteLine("Enter second number: ");
            while (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Invalid number. Enter again: ");
            }

            string operationsList = "Select Operation\n1. Sum\n2. Difference\n3. Product\n4. Quotient\n5. Remainder";
            Console.WriteLine(operationsList);

            string operation = Console.ReadLine();

            switch (operation) { 
                case "1":
                    Console.WriteLine($"The sum of {num1} and {num2} is {GetSum(num1, num2)}");
                    break;
                case "2":
                    Console.WriteLine($"The difference between {num1} and {num2} is {GetDifference(num1, num2)}");
                    break;
                case "3":
                    Console.WriteLine($"The product of {num1} and {num2} is {GetProduct(num1, num2)}");
                    break;
                case "4":
                    Console.WriteLine($"The quotient when {num1} is divided by {num2} is {GetQuotient(num1, num2)}");
                    break;
                case "5":
                    Console.WriteLine($"The remainder when {num1} is divided by {num2} is {GetRemainder(num1, num2)}");
                    break;
                default:
                    Console.WriteLine("Invalid Operation");
                    break;
            }
        }

        static void Main(string[] args)
        {
            RunCalculator();
        }
    }
}
