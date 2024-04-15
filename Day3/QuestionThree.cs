namespace ThirdProblem
{
    internal class QuestionThree
    {
        static List<double> GetNumbersFromUsers()
        {
            List<double> numbers = new List<double>();

            while (true)
            {
                Console.Write("Enter a number: ");
                double number;

                while (!double.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("Kindly enter a valid number!!");
                }

                if (number < 0)
                    break;

                numbers.Add(number);
            }

            return numbers;
        }

        static double GetAverageOfFactorsOfSeven(List<double> numbers)
        {
            double sum = 0.0;
            double count = 0;

            foreach (double number in numbers)
            {
                if (number % 7 == 0)
                {
                    sum += number;
                    count++;
                }
            }

            return sum / count;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Note: Enter a negative number to stop and get the average of all the numbers divisible by 7.");

            List<double> numbers = GetNumbersFromUsers();

            Console.WriteLine($"The average of numbers divisible by 7 is {GetAverageOfFactorsOfSeven(numbers)}");
        }
    }
}
