using System;
using System.Text;


namespace Ex01_01
{
    public class Program
    {

        public static void Main()
        {
            int      numbersToRead = 4;
            string[] numbersFromUser = receiveBinaryNumbersFromUser(numbersToRead);
            string[] binaryStrings = new string[numbersToRead];
            int[]    decimalValues = new int[numbersToRead];
            int[]    shiftCounts = new int[numbersToRead];
            int[]    onesCounts = new int[numbersToRead];
            int      valueOflongestOnesSequence = 0;
            string   numberWithLongestOnesSequence = "";
            int      mostOnesInNumber = 0;
            string   numberWithMostOnes = "";
            int      numberWithMostOnesDecimal = 0;
            int      totalOnes = 0;
            int      mostShifts = 0;
            string   numberWithMostShifts = "";

            for (int i = 0; i < numbersToRead; ++i)
            {
                binaryStrings[i] = numbersFromUser[i];

                decimalValues[i] = calculateDecimalValue(binaryStrings[i]);
                shiftCounts[i] = calculateShiftsOfOnesAndZeros(binaryStrings[i]);
                onesCounts[i] = countNumberOfOnes(binaryStrings[i]);

                if (onesCounts[i] >= mostOnesInNumber)
                {
                    mostOnesInNumber = onesCounts[i];
                    numberWithMostOnes = binaryStrings[i];
                    numberWithMostOnesDecimal = decimalValues[i];
                }

                totalOnes += onesCounts[i];

                int maxSequence = calculateLongestSequenceOfOnes(binaryStrings[i]);
                if (maxSequence >= valueOflongestOnesSequence)
                {
                    valueOflongestOnesSequence = maxSequence;
                    numberWithLongestOnesSequence = binaryStrings[i];
                }

                if (shiftCounts[i] >= mostShifts)
                {
                    mostShifts = shiftCounts[i];
                    numberWithMostShifts = binaryStrings[i];
                }
            }

            float averageValue = 0;
            for (int i = 0; i < numbersToRead; i++)
            {
                averageValue += decimalValues[i];
            }
            averageValue /= numbersToRead;

            sortArrayDescendingByDecimalValues(decimalValues);

            ShowStatistics(
                decimalValues,
                averageValue,
                valueOflongestOnesSequence,
                numberWithLongestOnesSequence,
                mostOnesInNumber,
                numberWithMostOnes,
                numberWithMostOnesDecimal,
                totalOnes,
                mostShifts,
                numberWithMostShifts
            );
        }

        public static string[] receiveBinaryNumbersFromUser(int i_NumOfNumbersToRead)
        {
            string msg = string.Format(
@"Hi there!
Please enter 4 numbers- represented in bits, 7 digit each.
Please click ""enter"" after every number given."
                                        );
            Console.WriteLine(msg);
            string[] binaryNumbers = new string[i_NumOfNumbersToRead];
            int numsRead = 0;

            while (numsRead < i_NumOfNumbersToRead)
            {
                string currentStringNum = Console.ReadLine();
                bool isNumberGood = isValidBinaryNumber(currentStringNum);

                if (isNumberGood == false)
                {
                    Console.WriteLine("You provided a wrong input. Please provide a 7 digits Binary number.");
                    continue;
                }

                binaryNumbers[numsRead++] = currentStringNum;
            }

            return binaryNumbers;
        }
        private static bool isValidBinaryNumber(string i_NumProvidedByUser)
        {
            const bool v_isValid = true;
            const int DigitsToRead = 7;
            bool result = v_isValid;

            if (i_NumProvidedByUser.Length != DigitsToRead)
            {
                result = !v_isValid;
            }
            else
            {
                foreach (char c in i_NumProvidedByUser)
                {
                    if (c != '0' && c != '1')
                    {
                        result = !v_isValid;
                        break;
                    }
                }
            }

            return result;
        }

        private static int calculateDecimalValue(string i_BinaryString)
        {
            int value = 0;
            int length = i_BinaryString.Length;
            for (int i = 0; i < length; i++)
            {
                int digit = (int)char.GetNumericValue(i_BinaryString[i]);
                value += (int)(digit * Math.Pow(2, length - i - 1));
            }
            return value;
        }

        private static int calculateShiftsOfOnesAndZeros(string i_BinaryString)
        {
            int shifts = 0;
            int prev = (int)char.GetNumericValue(i_BinaryString[0]);
            for (int i = 1; i < i_BinaryString.Length; i++)
            {
                int curr = (int)char.GetNumericValue(i_BinaryString[i]);
                if (curr != prev)
                {
                    shifts++;
                }
                prev = curr;
            }
            return shifts;
        }

        private static int countNumberOfOnes(string i_BinaryString)
        {
            int count = 0;
            foreach (char c in i_BinaryString)
            {
                if (c == '1')
                {
                    count++;
                }
            }
            return count;
        }

        private static int calculateLongestSequenceOfOnes(string i_BinaryString)
        {
            int maxSequence = 0;
            int currentSequence = 0;
            foreach (char c in i_BinaryString)
            {
                if (c == '1')
                {
                    currentSequence++;
                    maxSequence = Math.Max(maxSequence, currentSequence);
                }
                else
                {
                    currentSequence = 0;
                }
            }

            return maxSequence;
        }
        private static void sortArrayDescendingByDecimalValues(int[] i_DecimalValues)
        {
            for (int i = 0; i < i_DecimalValues.Length; i++)
            {
                for (int j = i + 1; j < i_DecimalValues.Length; j++)
                {
                    if (i_DecimalValues[i] < i_DecimalValues[j])
                    {
                        swap(ref i_DecimalValues[i], ref i_DecimalValues[j]);
                    }
                }
            }
        }
        private static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        private static void ShowStatistics(
      int[] i_DecimalValues,
      float i_AverageValue,
      int i_LongestOnesSequence,
      string i_NumberWithLongestOnesSequence,
      int i_MostOnesInNumber,
      string i_NumberWithMostOnes,
      int i_NumberWithMostOnesDecimal,
      int i_TotalOnes,
      int i_MostShifts,
      string i_NumberWithMostShifts)
        {
            Console.WriteLine("Sorted decimal values (descending):");
            foreach (int val in i_DecimalValues)
            {
                Console.WriteLine(val);
            }
            Console.WriteLine();
            Console.WriteLine($"Average of decimal values: {i_AverageValue}");
            Console.WriteLine($"Longest sequence of 1's: {i_LongestOnesSequence} (Binary: {i_NumberWithLongestOnesSequence})");
            Console.WriteLine($"Most shifts between 1's and 0's: {i_MostShifts} (Binary: {i_NumberWithMostShifts})");
            Console.WriteLine($"Most 1's in a number: {i_MostOnesInNumber} (Binary: {i_NumberWithMostOnes}, Decimal: {i_NumberWithMostOnesDecimal})");
            Console.WriteLine($"Total number of 1's in all numbers: {i_TotalOnes}");
        }

    }
}
