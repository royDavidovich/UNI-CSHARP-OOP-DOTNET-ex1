using System;
using System.Text;

namespace Ex01_05
{
    public class ConsoleHandler
    {   
        public static string RecieveUserInput()
        {
           string initMsg = string.Format(
@"Hello, Welcome to our final exercise.
Please enter a whole number with 8 digits: ");
            Console.WriteLine(initMsg);
            return getNumberFromUser();
        }
        private static string getNumberFromUser()
        {
            int validNumberLength = 8;
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int numberFromUser) && input.Length == validNumberLength;
            while (!success)
            {
                string initMsg = string.Format(@"Please enter a valid number with 8 digits only.");
                Console.WriteLine(initMsg);
                input = Console.ReadLine();
                success = int.TryParse(input, out numberFromUser) && input.Length == validNumberLength;
            }
            return input;
        }
        public static void ShowStatistics(NumberWithStatistics i_number)
        {
            int firstDigit = (int)(char.GetNumericValue(i_number.GetNumberAsString()[0]));
            int numOfDigitSmallerThanFirstDigit = i_number.GetNumOfDigitsSmallerThanFirstDigit();
            int numOfDigitsDivisibleBy3 = i_number.GetNumOfDigitsDivisibleBy3();
            string digitsDivisibleBy3 = i_number.GetDigitsDivisibleBy3().ToString();
            string digits = i_number.GetDigitsSmallerThanFirstDigit().ToString();
            int differenceBetweenLargestDigitToSmallestDigit = i_number.GetDifferenceBetweenLargestAndSmallestDigits();
            char mostCommonDigitInNumber = i_number.GetMostFrequentDigit();
            int frequencyOfMostCommonDigit = i_number.GetFrequencyOfMostFrequentDigit();

            Console.WriteLine();
            showNumberOfDigitsSmallerThenFirstDigit(firstDigit, numOfDigitSmallerThanFirstDigit, digits);   
            showHowManyDigitsDivisibleBy3(numOfDigitsDivisibleBy3, digitsDivisibleBy3);     
            showDifferenceBetweenLargestDigitToSmallestDigit(differenceBetweenLargestDigitToSmallestDigit);
            showMostCommonDigitAndNumberOfFrequency(mostCommonDigitInNumber, frequencyOfMostCommonDigit);
        }
        private static void showNumberOfDigitsSmallerThenFirstDigit(int i_firstDigit, int i_numOfDigitSmallerThanFirstDigit, string i_digits)
        {
            Console.Write(string.Format(
@"1.The first (most left) digit is {0}. There are {1} digits in the provided number 
which are smaller then {0}", i_firstDigit, i_numOfDigitSmallerThanFirstDigit));
            if (i_digits.Length > 0)
            {
                Console.WriteLine(string.Format(", which are {0}", i_digits));
            }
            Console.WriteLine();
        }
        private static void showHowManyDigitsDivisibleBy3(int i_numOfDigitsDivisibleBy3, string i_digitsDivisibleBy3)
        { 
            Console.WriteLine(string.Format(
@"2.There are {0} numbers which are divisible by 3, which are {1}", i_numOfDigitsDivisibleBy3, i_digitsDivisibleBy3));
            Console.WriteLine();
        }
        private static void showDifferenceBetweenLargestDigitToSmallestDigit(int i_differenceBetweenLargestDigitToSmallestDigit)
        {
            Console.WriteLine(string.Format(
@"3.The difference between the largest digit to the smallest digit is {0}.", i_differenceBetweenLargestDigitToSmallestDigit));
            Console.WriteLine();
        }
        private static void showMostCommonDigitAndNumberOfFrequency(char i_mostCommonDigit, int i_frequency)
        {
            Console.WriteLine(string.Format(
@"4.The most common digit in the provided number is {0}, which appeared {1} times.", i_mostCommonDigit, i_frequency));
            Console.WriteLine();
        }
    }
}
