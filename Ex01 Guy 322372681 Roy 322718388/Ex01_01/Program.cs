using System;
using System.Text;


namespace Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            const int k_numOfNumbers = 4;
            string[]  binaryNumbers = new string[k_numOfNumbers];
            int[]     decimalValues = new int[k_numOfNumbers], shiftsBetweenOnesAndZeros = new int[k_numOfNumbers];
            int       decimalValueOfNumberWithMostOnes = 0, totalOnesInAllNumbers = 0, mostOnesInNumber = 0, valueOfLongestOnesSequence = 0; 
            string    numberWithLongestOnesSequence = "", numberWithMostOnes = "", numberWithMostShifts = "";
            float     averageValue = 0f;

            binaryNumbers = receiveBinaryNumbersFromUser(k_numOfNumbers);
            for (int i = 0; i < k_numOfNumbers; ++i)
            {
                int currentNumberNumOfOnes = countNumberOfOnes(binaryNumbers[i]);
                int currentNumberMaxSequenceOfOnes = calculateLongestSequenceOfOnes(binaryNumbers[i]);
                decimalValues[i] = calculateDecimalValue(binaryNumbers[i]);
                shiftsBetweenOnesAndZeros[i] = calculateShiftsOfOnesAndZeros(binaryNumbers[i]);
                updateNumberWithMostOnes(currentNumberNumOfOnes, decimalValues[i], binaryNumbers[i], ref mostOnesInNumber, ref numberWithMostOnes, ref decimalValueOfNumberWithMostOnes);
                updateTotalOnes(currentNumberNumOfOnes, ref totalOnesInAllNumbers);
                updateNumberWithLongestSequenceOfOnes(currentNumberMaxSequenceOfOnes, binaryNumbers[i], ref valueOfLongestOnesSequence, ref numberWithLongestOnesSequence);   
            }
        
            averageValue = calculateAverageValue(decimalValues);
            sortArrayDescendingByDecimalValues(ref decimalValues);
            showStatistics(
                decimalValues,
                averageValue,
                valueOfLongestOnesSequence,
                numberWithLongestOnesSequence,
                mostOnesInNumber,
                numberWithMostOnes,
                decimalValueOfNumberWithMostOnes,
                totalOnesInAllNumbers,
                shiftsBetweenOnesAndZeros,
                binaryNumbers,
                numberWithMostShifts);
        }
        public static string[] receiveBinaryNumbersFromUser(int i_NumOfNumbersToRead)
        {
            string[] binaryNumbers = new string[i_NumOfNumbersToRead];
            int numsRead = 0;
            string msg = string.Format(
@"Hi there!
Please enter 4 numbers- represented in bits, 7 digit each.
Please click ""enter"" after every number given.");
            
            Console.WriteLine(msg);
            while (numsRead < i_NumOfNumbersToRead)
            {
                string currentStringNum = Console.ReadLine();
                bool   isNumberGood = isValidBinaryNumber(currentStringNum);
                if (!isNumberGood)
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
            const int  k_DigitsToRead = 7;
            bool       result = v_isValid;

            if (i_NumProvidedByUser.Length != k_DigitsToRead)
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
            int decimalValue = 0;
            int binaryStringLength = i_BinaryString.Length;

            for (int i = 0; i < binaryStringLength; ++i)
            {
                int digit = (int)char.GetNumericValue(i_BinaryString[i]);
                decimalValue += (int)(digit * Math.Pow(2, binaryStringLength - i - 1));
            }

            return decimalValue;
        }
        private static int calculateShiftsOfOnesAndZeros(string i_BinaryString)
        {
            int numOfshiftsInNumber = 0;
            int prevDigit = (int)char.GetNumericValue(i_BinaryString[0]);
            for (int i = 1; i < i_BinaryString.Length; ++i)
            {
                int currentDigit = (int)char.GetNumericValue(i_BinaryString[i]);
                if (currentDigit != prevDigit)
                {
                    numOfshiftsInNumber++;
                }

                prevDigit = currentDigit;
            }

            return numOfshiftsInNumber;
        }
        private static void updateNumberWithMostOnes(
    int        i_CurrentNumberNumOfOnes,
    int        i_CurrentNumberDecimalValue,
    string     i_CurrentBinaryNumber,
    ref int    io_MostOnesInNumber,
    ref string o_NumberWithMostOnes,
    ref int    o_NumberWithMostOnesDecimal)
        {
            if (i_CurrentNumberNumOfOnes > io_MostOnesInNumber)
            {
                io_MostOnesInNumber = i_CurrentNumberNumOfOnes;
                o_NumberWithMostOnes = i_CurrentBinaryNumber;
                o_NumberWithMostOnesDecimal = i_CurrentNumberDecimalValue;
            }
        }
        private static void updateTotalOnes(int i_CurrentOnesCount, ref int io_TotalOnes)
        {
            io_TotalOnes += i_CurrentOnesCount;
        }
        private static void updateNumberWithLongestSequenceOfOnes(
    int         i_CurrentSequenceOfOnes,
    string      i_CurrentBinaryNumber,
    ref int     io_ValueOfLongestOnesSequence,
    ref string  o_NumberWithLongestOnesSequence)
        {
            if (i_CurrentSequenceOfOnes > io_ValueOfLongestOnesSequence)
            {
                io_ValueOfLongestOnesSequence = i_CurrentSequenceOfOnes;
                o_NumberWithLongestOnesSequence = i_CurrentBinaryNumber;
            }
        }
        private static int countNumberOfOnes(string i_BinaryString)
        {
            int numOfOnesInNumber = 0;
            foreach (char c in i_BinaryString)
            {
                if (c == '1')
                {
                    ++numOfOnesInNumber;
                }
            }

            return numOfOnesInNumber;
        }
        private static int calculateLongestSequenceOfOnes(string i_BinaryString)
        {
            int maxSequenceOfOnes = 0;
            int currentSequenceofOnes = 0;
            foreach (char c in i_BinaryString)
            {
                if (c == '1')
                {
                    ++currentSequenceofOnes;
                    maxSequenceOfOnes = Math.Max(maxSequenceOfOnes, currentSequenceofOnes);
                }
                else
                {
                    currentSequenceofOnes = 0;
                }
            }

            return maxSequenceOfOnes;
        }
        private static float calculateAverageValue(int[] i_DecimalValues)
        {
            float sumOfAllDecimalValues = 0;
            for (int i = 0; i < i_DecimalValues.Length; ++i)
            {
                sumOfAllDecimalValues += i_DecimalValues[i];
            }

            return sumOfAllDecimalValues / i_DecimalValues.Length;
        }

        private static void sortArrayDescendingByDecimalValues(ref int[] io_DecimalValues)
        {
            for (int i = 0; i < io_DecimalValues.Length; ++i)
            {
                for (int j = i + 1; j < io_DecimalValues.Length; ++j)
                {
                    if (io_DecimalValues[i] < io_DecimalValues[j])
                    {
                        swap(ref io_DecimalValues[i], ref io_DecimalValues[j]);
                    }
                }
            }
        }
        private static void swap(ref int io_A, ref int io_B)
        {
            int temp = io_A;
            io_A = io_B;
            io_B = temp;
        }
        private static void showStatistics(
      int[]     i_DecimalValues,
      float     i_AverageValue,
      int       i_LongestOnesSequence,
      string    i_NumberWithLongestOnesSequence,
      int       i_MostOnesInNumber,
      string    i_NumberWithMostOnes,
      int       i_NumberWithMostOnesDecimal,
      int       i_TotalOnes,
      int[]     i_ShiftsBetweenOnesAndZeros,
      string[]  i_BinaryNumbers,
      string    i_NumberWithMostShifts)
        {
            Console.WriteLine("Sorted decimal values (descending):");
            foreach (int val in i_DecimalValues)
            {
                Console.WriteLine(val);
            }

            Console.WriteLine();
            Console.WriteLine($"Average of decimal values: {i_AverageValue}");
            Console.WriteLine($"Longest sequence of 1's: {i_LongestOnesSequence} (Binary: {i_NumberWithLongestOnesSequence})");
            Console.WriteLine("\nShifts between 1's and 0's for each number:");
            for (int i = 0; i < i_BinaryNumbers.Length; ++i)
            {
                Console.WriteLine($"{i_ShiftsBetweenOnesAndZeros[i]} ({i_BinaryNumbers[i]})");
            }

            Console.WriteLine($"\nMost 1's in a number: {i_MostOnesInNumber} (Binary: {i_NumberWithMostOnes}, Decimal: {i_NumberWithMostOnesDecimal})");
            Console.WriteLine($"Total number of 1's in all numbers: {i_TotalOnes}");
        }
    }
}
