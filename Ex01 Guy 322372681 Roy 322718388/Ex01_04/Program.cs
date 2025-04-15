using System;
using System.Linq;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            string userInput = recieveUsersInput();
            bool isMyStringPolindrome = checkForPalindrome(userInput);

            Console.WriteLine(string.Format("Is palindrome: {0}", isMyStringPolindrome ? "Yes" : "No"));
            if (isStringRepresentsANumberAndNumberDivisableBy3(userInput, out bool o_IsDivisiableBy3))
            {
                Console.WriteLine(string.Format("Is divisiable by 3 w/o remainder: {0}", o_IsDivisiableBy3 ? "Yes" : "No"));
            }

            if (isStringAllEnglishLetters(userInput, out int numberOfUppercaseLetters, out bool isStringAscendingAlphabetical))
            {
                Console.WriteLine(string.Format(
@"Number of UPPERCASE letters: {0}
Is ascending alphabetical order? {1}", numberOfUppercaseLetters, isStringAscendingAlphabetical ? "Yes" : "No"));
            }
        }
        private static string recieveUsersInput()
        {
            string initMsg = string.Format(
@"Hello there!
Welcome to our fourth program. Lets have some FUN!
Please enter a 12 charachters long string: ");

            Console.WriteLine(initMsg);
            getValidUserString(out string o_UserString);

            return o_UserString;    
        }
        private static void getValidUserString(out string o_UserString)
        {
            int inputStringLen = 12;

            o_UserString = Console.ReadLine();
            while (o_UserString.Length != inputStringLen)
            {
                Console.WriteLine("Please keep input string to 12 charachters. Please try again: ");
                o_UserString = Console.ReadLine();
            }
        }
        private static bool checkForPalindrome(string i_SuspectedPalindrome)
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
        private static bool isStringRepresentsANumberAndNumberDivisableBy3(string i_SuspectedNumber, out bool o_IsDivisiableBy3)
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
        private static bool isStringAllEnglishLetters(string i_SuspectedString, out int o_NumberOfUppercaseLetters, out bool o_IsAscendingAlphabetical)
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
