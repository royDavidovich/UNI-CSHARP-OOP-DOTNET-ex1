using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    public class ConsoleTalker
    {
        public static string[] ReceiveBooleanNumbersFromUser(int i_numOfNumbersToRead)
        {
            string msg = string.Format(
@"Hi there, fellow man!
Please enter 4 numbers- represented in bits, 7 digit each.
Please click ""enter"" after every number given."
                                        );
            Console.WriteLine(msg);
            string[] booleanNumbers = new string[i_numOfNumbersToRead]; 
            int numsRead = 0;
            while(numsRead < i_numOfNumbersToRead)
            {
                string currentStringNum = Console.ReadLine();
                bool isNumberGood = numberIsNotGood(currentStringNum);
                if(isNumberGood == false)
                {
                    Console.WriteLine("You provided a wrong input. Please provide a 7 digits boolean number.");
                    continue;
                }
                booleanNumbers[numsRead++] = currentStringNum;
            }
            return booleanNumbers;
        }

        private static bool numberIsNotGood(string i_numProvidedByUser)
        {
            bool isTheNumberGood = true;        // NTS - not using convention
            int digitsToRead = 7;               // NTS - magic number
            int numberLength = i_numProvidedByUser.Length;
            if(numberLength == digitsToRead)
            {
                foreach(char c in i_numProvidedByUser)
                {
                    if(c != '0' && c != '1')
                    {
                        isTheNumberGood = false;
                        break;
                    }
                }
            }
            else
            {
                isTheNumberGood = false;
            }
            return isTheNumberGood;
        }

        public static void ShowStatistics(BooleanNumber[] i_arrayOfBooleanNumbers)
        {
            Console.WriteLine("Numbers in descending order:");
            string decimalValues = "";
            for (int i = 0; i < i_arrayOfBooleanNumbers.Length; i++)
            {
                decimalValues += string.Format("{0}", i_arrayOfBooleanNumbers[i].GetDecimalNumber());
                if (i < i_arrayOfBooleanNumbers.Length - 1)
                {
                    decimalValues += ", ";
                }
            }
            Console.WriteLine(decimalValues);
            float averageValue = BooleanNumber.GetAverageDecimalValue();
            Console.WriteLine("Average value of decimal numbers is " + averageValue);
            string msg = string.Format("Most Ones sequence in number is {0}, in the number {1}", BooleanNumber.GetLongestOnesSequence()[0],
                i_arrayOfBooleanNumbers[BooleanNumber.GetLongestOnesSequence()[1]].GetMyNumberInString());
            Console.WriteLine(msg);
            Console.WriteLine("Number of switches between One and Zero:");
            foreach (BooleanNumber number in i_arrayOfBooleanNumbers)
            {
                 msg = string.Format("{0} (for number {1}), " ,number.GetShiftsBetweenOnesAndZeros(),
                    number.GetMyNumberInString());
                Console.WriteLine(msg);
            }
            msg = string.Format("Most ones in number is {0} (Binary : {1})", i_arrayOfBooleanNumbers[BooleanNumber.GetMostOnesInNumber()[1]].GetDecimalNumber(),
                i_arrayOfBooleanNumbers[BooleanNumber.GetMostOnesInNumber()[1]].GetMyNumberInString());
            Console.WriteLine(msg);
            msg = string.Format("Total number of ones: {0}", BooleanNumber.GetNumberOfOnesInAllNumbers());
            Console.WriteLine(msg);
        }

    }
}
