using System;


namespace Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            string msg = string.Format(
@"Hi there, fellow man!
Please enter 4 numbers represented by bits, 7 digit each.
Please click ""enter"" after every number given.");
            Console.WriteLine(msg);
            string[] numbersFromUser = NumberTaker.ReceiveBooleanNumbersFromUser();
            Console.WriteLine(numbersFromUser.Length);
            foreach(string number in numbersFromUser)
            {
                Console.WriteLine(number);
            }
        }
    }
}
