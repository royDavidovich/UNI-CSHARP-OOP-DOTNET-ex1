using System.Linq;
using System.Runtime.InteropServices;

namespace Ex01_04
{
    public class StringCheckingFunctions
    {
        public static bool CheckForPalindrome(string i_SuspectedPalindrome)
        {
            i_SuspectedPalindrome = i_SuspectedPalindrome.ToUpper();
            bool isPalindrome = checkForPalindromeHelper(i_SuspectedPalindrome);

            return isPalindrome;
        }
        private static bool checkForPalindromeHelper(string i_SuspectedPalindrome)
        {
            bool isPalindrome = true;
            int inputStringLength = i_SuspectedPalindrome.Length;

            if (inputStringLength <= 1)
            {
                isPalindrome = true;
            }
            else
            {
                char FirstLetterInSuspectedPalindrome = i_SuspectedPalindrome[0];
                char LastLetterInSuspectedPalindrome = i_SuspectedPalindrome[inputStringLength - 1];
                string newSuspectedPalindrome = i_SuspectedPalindrome.Substring(1, inputStringLength - 2);

                if (FirstLetterInSuspectedPalindrome != LastLetterInSuspectedPalindrome)
                {
                    isPalindrome = false;
                }

                isPalindrome = (isPalindrome && checkForPalindromeHelper(newSuspectedPalindrome));
            }

            return isPalindrome;
        }

        public static bool IsStringRepresentsANumberAndNumberDivisableBy3(string i_SuspectedNumber, out bool o_IsDivisiableBy3)
        {
            bool isStringANumber = isStringRepresentsANumber(i_SuspectedNumber, out long parsedInputNumber);
            if (isStringANumber && (parsedInputNumber % 3 == 0))
            {
                o_IsDivisiableBy3 = true;
            }
            else
            {
                o_IsDivisiableBy3 = false;
            }

            return isStringANumber;
        }
        
        private static bool isStringRepresentsANumber(string i_SuspectedNumber, out long o_RepresentedNumber)
        {
            return long.TryParse(i_SuspectedNumber, out o_RepresentedNumber);
        }
    }
}