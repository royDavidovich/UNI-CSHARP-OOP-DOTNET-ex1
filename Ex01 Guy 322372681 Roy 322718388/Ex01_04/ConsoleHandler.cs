using System;

namespace Ex01_04
{
    internal class ConsoleHandler
    {
        public static void RecieveUsersInput()
        {
            string initMsg = string.Format(
@"Hello there!
Welcome to our fourth program. Lets have some FUN!
Please enter a 12 charachters long string: ");
            Console.WriteLine(initMsg);
            getValidUserString(out string userString);

            //functions
            bool isMyStringPolindrome = StringCheckingFunctions.CheckForPalindrome(userString);
            Console.WriteLine(string.Format("Is palindrome: {0}", isMyStringPolindrome ? "Yes":"No"));

            if (StringCheckingFunctions.IsStringRepresentsANumberAndNumberDivisableBy3(userString, out bool isDivisiableBy3))
            {
                Console.WriteLine(string.Format("Is divisiable by 3 w/o remainder: {0}", isDivisiableBy3 ? "Yes" : "No"));
            }

            if (StringCheckingFunctions.IsStringAllEnglishLetters(userString, out int numberOfUppercaseLetters, out bool isStringAscendingAlphabetical))
            {
                Console.WriteLine(string.Format(
@"Number of UPPERCASE letters: {0}
Is ascending alphabetical order? {1}", numberOfUppercaseLetters, isStringAscendingAlphabetical ? "Yes" : "No"));
            }
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
    }
}