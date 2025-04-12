using System;

namespace Ex01_04
{
    internal class ConsoleHnadler
    {
        public static void RecieveUsersInput()
        {
            int inputStringLen = 12;

            string initMsg = string.Format(
@"Hello there!
Welcome to our fourth program. Lets have some FUN!
Please enter a 12 charachters long string: ");
            Console.WriteLine(initMsg);
            string userString = Console.ReadLine();

            //functions
            bool isMyStringPolindrome = StringCheckingFunctions.CheckForPalindrome(userString);
            Console.WriteLine(string.Format("is palindrome: {0}", isMyStringPolindrome ? "Yes":"No"));

            if (StringCheckingFunctions.IsStringRepresentsANumberAndNumberDivisableBy3(userString, out bool isDivisiableBy3))
            {
                Console.WriteLine(string.Format("is divisiable by 3 w/o remainder: {0}", isDivisiableBy3 ? "Yes" : "No"));
            }
        }
    }
}