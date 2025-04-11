using System;
using Ex01_02;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            int usersNumOfRows;
            Console.Write("Enter number of rows: ");
            bool isUserInputValid = int.TryParse(Console.ReadLine(), out usersNumOfRows);
            while (!isUserInputValid || usersNumOfRows < 4 || usersNumOfRows > 15)
            {
                Console.Write("Invalid input. Please enter a number between 4 and 15: ");
                isUserInputValid = int.TryParse(Console.ReadLine(), out usersNumOfRows);
            }
            Console.WriteLine();
            RecursiveTree.PrintTree(usersNumOfRows);
        }
    }
}