using System.Linq;

namespace Ex01_04
{
    public class PalindromeChecker
    {
        public static bool CheckForPalindrome(string i_SuspectedPalindrome)
        {
            i_SuspectedPalindrome = i_SuspectedPalindrome.ToUpper();
            bool isPalindrome = CheckForPalindromeHelper(i_SuspectedPalindrome);

            return isPalindrome;
        }
        public static bool CheckForPalindromeHelper(string i_SuspectedPalindrome)
        {
            bool isPalindrome = true;
            int InputStringLength = i_SuspectedPalindrome.Length;

            if (InputStringLength <= 1)
            {
                isPalindrome = true;
            }
            else
            {
                char FirstLetterInSuspectedPalindrome = i_SuspectedPalindrome[0];
                char LastLetterInSuspectedPalindrome = i_SuspectedPalindrome[InputStringLength - 1];
                string newSuspectedPalindrome = i_SuspectedPalindrome.Substring(1, InputStringLength - 2);

                if (FirstLetterInSuspectedPalindrome != LastLetterInSuspectedPalindrome)
                {
                    isPalindrome = false;
                }

                isPalindrome = (isPalindrome && CheckForPalindromeHelper(newSuspectedPalindrome));
            }

            return isPalindrome;
        }
    }
}