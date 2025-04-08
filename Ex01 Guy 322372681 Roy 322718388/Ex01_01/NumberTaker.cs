using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    public class NumberTaker
    {
        public static string[] ReceiveBooleanNumbersFromUser()
        {
            int numOfNumbersToRead = 4;
            string[] booleanNumbers = new string[numOfNumbersToRead]; 
            int numsRead = 0;
            while(numsRead < numOfNumbersToRead)
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
            bool isTheNumberGood = true;
            int digitsToRead = 7;
            int numberLength = i_numProvidedByUser.Length;
            if(numberLength == digitsToRead)
            {
                foreach (char c in i_numProvidedByUser)
                {
                    if (c != '0' && c != '1')
                    {
                        isTheNumberGood = false;
                        break;
                    }
                }
            }

            return isTheNumberGood;
        }
    }
}
