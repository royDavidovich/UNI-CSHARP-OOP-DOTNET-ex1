using System;

namespace Ex01_04
{
    internal class ConsoleHnadler
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
            Console.WriteLine(string.Format("is palindrome: {0}", isMyStringPolindrome ? "Yes":"No"));

            if (StringCheckingFunctions.IsStringRepresentsANumberAndNumberDivisableBy3(userString, out bool isDivisiableBy3))
            {
                Console.WriteLine(string.Format("is divisiable by 3 w/o remainder: {0}", isDivisiableBy3 ? "Yes" : "No"));
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