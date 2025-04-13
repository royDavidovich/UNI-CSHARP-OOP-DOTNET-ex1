using System;
using System.Diagnostics.Eventing.Reader;
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

        public static bool IsStringAllEnglishLetters(string i_SuspectedString, out int o_NumberOfUppercaseLetters, out bool o_IsAscendingAlphabetical)
        {
            o_NumberOfUppercaseLetters = 0;
            o_IsAscendingAlphabetical = false;
            bool doesStringContainsDigits = i_SuspectedString.Any(char.IsDigit);
            bool validAllLettersString = !doesStringContainsDigits;

            if (validAllLettersString)
            {
                o_NumberOfUppercaseLetters = countUppercasedLetters(i_SuspectedString);
                o_IsAscendingAlphabetical = isStringSortedAlphabetically(i_SuspectedString);
            }

            return validAllLettersString;
        }

        private static int countUppercasedLetters(string i_SuspectedString)
        {
            int numberOfUppercaseLetters = 0;
            i_SuspectedString = new string(i_SuspectedString.Distinct().ToArray());
            
            for (int i = 0; i < i_SuspectedString.Length; i++)
            {
                if (char.IsUpper(i_SuspectedString[i]))
                {
                    ++numberOfUppercaseLetters;
                }
            }

            return numberOfUppercaseLetters;
        }

        private static bool isStringSortedAlphabetically(string i_SuspectedString)
        {
            bool isStringAscendingAlphabetical = true;
            i_SuspectedString = i_SuspectedString.ToUpper();

            for (int i = 1; i < i_SuspectedString.Length; i++)
            {
                if (i_SuspectedString[i - 1] > i_SuspectedString[i])
                {
                    isStringAscendingAlphabetical = false;
                    break;
                }
            }

            return isStringAscendingAlphabetical;
        }
    }
}