using System;
using System.Text;

namespace Ex01_01
{
    public class ConsoleTalker
    {
        public static string[] ReceiveBinaryNumbersFromUser(int i_NumOfNumbersToRead)
        {
            string msg = string.Format(
@"Hi there!
Please enter 4 numbers- represented in bits, 7 digit each.
Please click ""enter"" after every number given."
                                        );
            Console.WriteLine(msg);
            string[] BinaryNumbers = new string[i_NumOfNumbersToRead]; 
            int numsRead = 0;

            while(numsRead < i_NumOfNumbersToRead)
            {
                string currentStringNum = Console.ReadLine();
                bool isNumberGood = isValidBinaryNumber(currentStringNum);

                if(isNumberGood == false)
                {
                    Console.WriteLine("You provided a wrong input. Please provide a 7 digits Binary number.");
                    continue;
                }

                BinaryNumbers[numsRead++] = currentStringNum;
            }

            return BinaryNumbers;
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

        public static void ShowStatistics(BinaryNumber[] i_ArrayOfBinaryNumbers)
        {
            showNumbersInDescendingOrder(i_ArrayOfBinaryNumbers);
            showAverageDecimalValue();
            showLongestSequenceOfOnes(i_ArrayOfBinaryNumbers);
            showSwitchesBetweenOnesAndZeros(i_ArrayOfBinaryNumbers);
            showMostOnesInNumber(i_ArrayOfBinaryNumbers);
            showTotalNumberOfOnes();
        }

        private static void showNumbersInDescendingOrder(BinaryNumber[] i_Array)
        {
            Console.WriteLine("Numbers in descending order:");
            StringBuilder decimalValues = new StringBuilder();

            for (int i = 0; i < i_Array.Length; i++)
            {
                decimalValues.Append(i_Array[i].GetDecimalNumber());
                if (i < i_Array.Length - 1)
                {
                    decimalValues.Append(", ");
                }
            }

            Console.WriteLine(decimalValues.ToString());
        }
        private static void showAverageDecimalValue()
        {
            float averageValue = BinaryNumber.GetAverageDecimalValue();

            Console.WriteLine(string.Format("Average value of decimal numbers is {0}", averageValue));
        }
        private static void showLongestSequenceOfOnes(BinaryNumber[] i_Array)
        {
            int longestSequence = BinaryNumber.GetLongestOnesSequence();

            Console.WriteLine(string.Format(
                "Longest sequence of ones is {0}, in number {1}",
                longestSequence, BinaryNumber.GetNumberWithLongestOneSequence()));
        }
        private static void showSwitchesBetweenOnesAndZeros(BinaryNumber[] i_Array)
        {
            Console.WriteLine("Number of switches between One and Zero:");
            foreach (BinaryNumber number in i_Array)
            {
                Console.WriteLine(string.Format(
                "{0} (for number {1})",
                    number.GetShiftsBetweenOnesAndZeros(),
                    number.GetMyNumberInString()));
            }
        }
        private static void showMostOnesInNumber(BinaryNumber[] i_Array)
        {
            int mostOnes = BinaryNumber.GetMostOnesInNumber();
            int decimalNumber = BinaryNumber.GetNumberWithMostOnesAsDecimal();
            string binaryNumber = BinaryNumber.GetNumberWithMostOnesAsBinary();

            Console.WriteLine(string.Format(
                "Most ones are {0} in number {1} (Binary representation: {2})", mostOnes, decimalNumber, binaryNumber));
        }
        private static void showTotalNumberOfOnes()
        {
            Console.WriteLine(string.Format(
                "Total number of ones: {0}",
                BinaryNumber.GetNumberOfOnesInAllNumbers()));
        }

    }
}
