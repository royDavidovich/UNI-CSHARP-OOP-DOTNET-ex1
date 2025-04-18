using System;
namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter number of rows: ");
            int o_usersNumOfRows;
            bool isUserInputValid = int.TryParse(Console.ReadLine(), out o_usersNumOfRows);

            while (!isUserInputValid || o_usersNumOfRows < 4 || o_usersNumOfRows > 15)
            {
                Console.Write("Invalid input. Please enter a number between 4 and 15: ");
                isUserInputValid = int.TryParse(Console.ReadLine(), out o_usersNumOfRows);
            }

            Console.WriteLine();
            Ex01_02.Program.PrintTree(o_usersNumOfRows);
        }
    }
}