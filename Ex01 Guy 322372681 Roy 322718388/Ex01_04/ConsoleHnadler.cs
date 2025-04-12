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
            string usersString = Console.ReadLine();

            //functions
            bool isMyStringPolindrome = PalindromeChecker.CheckForPalindrome(usersString);
            Console.WriteLine(string.Format("is palindrome: {0}", isMyStringPolindrome ? "Yes":"No"));


        }
    }
}
