using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Card
    {
        public string CardNumber { get; set; } = string.Empty;

        /// <summary>
        /// Reverses the given card number
        /// </summary>
        /// <param name="cardNumber">Card Number as String</param>
        /// <returns>Integer array of reversed digits of the card number</returns>
        static int[] ReverseCardNumber (string cardNumber)
        {
            int[] reversedCardNumber = new int[cardNumber.Length];

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                reversedCardNumber[i] = int.Parse(cardNumber[i].ToString());
            }

            return reversedCardNumber;
        }

        /// <summary>
        /// Check if the given card number contains only numbers and is of length 16
        /// </summary>
        /// <param name="cardNumber">Card Number as String</param>
        /// <returns>True if card number contains only numbers and is of length 16 or vice versa</returns>
        static bool CheckIfCardNumberIsANumber (string cardNumber)
        {
            if (cardNumber.Length != 16) return false;

            if (!long.TryParse (cardNumber, out _))
            {
                return false;
            }

            return true;    
        }

        /// <summary>
        /// Reduces two digit numbers into single digit by adding them
        /// </summary>
        /// <param name="digit">Either a single digit or a double digit number</param>
        /// <returns>Returns the sum of digits if the number has two digits</returns>
        static int ReduceToSingleDigit (int digit)
        {
            if (digit > 9)
            {
                int tensPlace = digit / 2;
                int onesPlace = digit % 2;

                return tensPlace + onesPlace;
            }

            return digit;
        }

        /// <summary>
        /// Multiply 2 with the digits in even places
        /// </summary>
        /// <param name="reversedCardNumber">Integer array of reversed card number</param>
        /// <returns>Returns array of numbers having even place numbers multiplied by 2</returns>
        static int[] MultiplyTwoWithEvenPlaceNumbers(int[] reversedCardNumber)
        {
            int[] twoMultipliedNumbers = new int[reversedCardNumber.Length];

            for (int i = 0; i < reversedCardNumber.Length; i++)
            {
                if (i % 2 == 0) twoMultipliedNumbers[i] = reversedCardNumber[i];
                else twoMultipliedNumbers[i] = ReduceToSingleDigit(reversedCardNumber[i] * 2);
            }

            return twoMultipliedNumbers;
        }

        /// <summary>
        /// Calculate the sum of the digits in the card numbers
        /// </summary>
        /// <param name="twoMultipliedNumbers">Integer array of numbers having even place numbers multiplied by 2</param>
        /// <returns>Sum of digits in the card number</returns>
        static int SumOfDigitsInCardNumber(int[] twoMultipliedNumbers)
        {
            int sum = 0;

            for (int i = 0; i < twoMultipliedNumbers.Length; i++)
            {
                sum += twoMultipliedNumbers[i];
            }

            return sum;
        }

        /// <summary>
        /// Validates a card number
        /// </summary>
        /// <param name="cardNumber">Card number as string</param>
        /// <returns>True if card number is valid and false otherwise</returns>
        static bool ChecksIfCardNumberIsValid (string cardNumber)
        {
            if (!CheckIfCardNumberIsANumber(cardNumber)) return false;

            int[] reversedCardNumber = ReverseCardNumber(cardNumber);

            int[] twoMultipliedNumbers = MultiplyTwoWithEvenPlaceNumbers(reversedCardNumber);

            int sumOfNumbers = SumOfDigitsInCardNumber(twoMultipliedNumbers);

            if (sumOfNumbers % 10 != 0) return false;

            return true;
        }

        static void Main(string[] args)
        {
            Card card = new Card();
            Console.Write("Enter card number: ");
            card.CardNumber = Console.ReadLine() ?? "";

            if (ChecksIfCardNumberIsValid(card.CardNumber))
            {
                Console.WriteLine("Valid Card Number");
                return; 
            }

            Console.WriteLine("Invalid Card Number");
        }
    }
}
