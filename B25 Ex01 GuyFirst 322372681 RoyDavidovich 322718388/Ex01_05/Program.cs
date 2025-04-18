using System;
using System.Linq;
using System.Text;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            string        numberAsString = RecieveUserInput();
            int           numOfDigitsSmallerThanFirstDigit;
            int           frequencyOfMostFrequentDigit;
            int           numOfDigitsDivisibleBy3;
            int           differenceBetweenLargestAndSmallestDigits;
            char          mostFrequentDigit;
            StringBuilder digitsDivisibleBy3;
            StringBuilder digitsSmallerThanFirstDigit;

            CalculateStatisticsOnNumber(
                numberAsString,
                out numOfDigitsSmallerThanFirstDigit,
                out digitsSmallerThanFirstDigit,
                out numOfDigitsDivisibleBy3,
                out digitsDivisibleBy3,
                out differenceBetweenLargestAndSmallestDigits,
                out mostFrequentDigit,
                out frequencyOfMostFrequentDigit
            );
            ShowStatistics(
                numberAsString,
                numOfDigitsSmallerThanFirstDigit,
                digitsSmallerThanFirstDigit,
                numOfDigitsDivisibleBy3,
                digitsDivisibleBy3,
                differenceBetweenLargestAndSmallestDigits,
                mostFrequentDigit,
                frequencyOfMostFrequentDigit
            );
        }
        private static string RecieveUserInput()
        {
            string inputFromUser;
            bool isValid;

            do
            {
                Console.Write("Enter a number with exactly 8 digits: ");
                inputFromUser = Console.ReadLine();
                isValid = (inputFromUser.Length == 8 && inputFromUser.All(char.IsDigit));
                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter exactly 8 digits (0-9).");
                }

            } while (!isValid);

            return inputFromUser;
        }
        private static void CalculateStatisticsOnNumber(
            string            i_NumberAsString,
            out int           o_NumOfDigitsSmallerThanFirstDigit,
            out StringBuilder o_DigitsSmallerThanFirstDigit,
            out int           o_NumOfDigitsDivisibleBy3,
            out StringBuilder o_DigitsDivisibleBy3,
            out int           o_DifferenceBetweenLargestAndSmallestDigits,
            out char          o_MostFrequentDigit,
            out int           o_FrequencyOfMostFrequentDigit)
        {
            HowManyNumbersAreSmallerThanFirstDigit(i_NumberAsString, out o_NumOfDigitsSmallerThanFirstDigit, out o_DigitsSmallerThanFirstDigit);
            HowManyNumbersDivisibleBy3(i_NumberAsString, out o_NumOfDigitsDivisibleBy3, out o_DigitsDivisibleBy3);
            DifferenceFromLargestDigitToSmallestDigit(i_NumberAsString, out o_DifferenceBetweenLargestAndSmallestDigits);
            MostCommonDigitAndNumberOfAppearances(i_NumberAsString, out o_MostFrequentDigit, out o_FrequencyOfMostFrequentDigit);
        }
        private static void HowManyNumbersAreSmallerThanFirstDigit(string i_Number, out int o_NumOfDigitsSmallerThanFirstDigit, out StringBuilder o_Digits)
        {
            o_NumOfDigitsSmallerThanFirstDigit = 0;
            o_Digits = new StringBuilder();
            char firstDigit = i_Number[0];

            for (int i = 1; i < i_Number.Length; ++i)
            {
                if (char.GetNumericValue(i_Number[i]) < char.GetNumericValue(firstDigit))
                {
                    ++o_NumOfDigitsSmallerThanFirstDigit;
                    o_Digits.Append(i_Number[i]);
                    o_Digits.Append(' ');
                }
            }
        }
        private static void HowManyNumbersDivisibleBy3(string i_Number, out int o_NumOfDigitsDivisibleBy3, out StringBuilder o_DigitsDevisibleBy3)
        {
            o_NumOfDigitsDivisibleBy3 = 0;
            o_DigitsDevisibleBy3 = new StringBuilder();
            for (int i = 0; i < i_Number.Length; ++i)
            {
                if (char.GetNumericValue(i_Number[i]) % 3 == 0)
                {
                    o_DigitsDevisibleBy3.Append(i_Number[i]);
                    o_DigitsDevisibleBy3.Append(' ');
                    ++o_NumOfDigitsDivisibleBy3;
                }
            }
        }
        private static void DifferenceFromLargestDigitToSmallestDigit(string i_Number, out int o_Difference)
        {
            int maxDigit = int.MinValue;
            int minDigit = int.MaxValue;

            for (int i = 0; i < i_Number.Length; ++i)
            {
                int currentDigit = (int)char.GetNumericValue(i_Number[i]);
				
                maxDigit = Math.Max(currentDigit, maxDigit);
                minDigit = Math.Min(currentDigit, minDigit);
            }

            o_Difference = maxDigit - minDigit;
        }
        private static void MostCommonDigitAndNumberOfAppearances(string i_Number, out char o_MostFrequentDigit, out int o_MaxFrequency)
        {
            string uniqueDigits = "0123456789";
			
            o_MaxFrequency = 0;
            o_MostFrequentDigit = '0';

            // Checks each digit 0–9 by removing it from the string and comparing length differences to count occurrences.
            foreach (char digit in uniqueDigits)
            {
                int currentDigitFrequency = i_Number.Length - i_Number.Replace(digit.ToString(), "").Length;
				
                if (currentDigitFrequency > o_MaxFrequency)
                {
                    o_MaxFrequency = currentDigitFrequency;
                    o_MostFrequentDigit = digit;
                }
            }
        }
        private static void ShowStatistics(
            string          i_Number,
            int             i_NumOfDigitsSmallerThanFirstDigit,
            StringBuilder   i_DigitsSmallerThanFirstDigit,
            int             i_NumOfDigitsDivisibleBy3,
            StringBuilder   i_DigitsDivisibleBy3,
            int             i_DifferenceBetweenLargestAndSmallestDigits,
            char            i_MostFrequentDigit,
            int             i_FrequencyOfMostFrequentDigit)
        {
            Console.WriteLine($"Number: {i_Number}");
            Console.WriteLine($"Digits smaller than first digit ({i_Number[0]}): {i_DigitsSmallerThanFirstDigit}({i_NumOfDigitsSmallerThanFirstDigit})");
            Console.WriteLine($"Digits divisible by 3: {i_DigitsDivisibleBy3}({i_NumOfDigitsDivisibleBy3})");
            Console.WriteLine($"Difference between largest and smallest digits: {i_DifferenceBetweenLargestAndSmallestDigits}");
            Console.WriteLine($"Most frequent digit: {i_MostFrequentDigit} ({i_FrequencyOfMostFrequentDigit} times)");
        }
    }
}