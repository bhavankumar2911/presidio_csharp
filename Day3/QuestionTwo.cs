using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDayProblems
{
    internal class QuestionTwo
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();

            Console.WriteLine("Note: Enter a negative number to stop and get the greatest of all entered numbers.");

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

            double result = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                result = Math.Max(result, numbers[i]);
            }

            Console.WriteLine($"{result} is the greatest number");
        }
    }
}
