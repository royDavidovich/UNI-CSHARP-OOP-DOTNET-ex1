using System;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            int numRows = 7;
            PrintTree(numRows);
        }

        public static void PrintTree(int i_NumOfRows)
        {
            printTreeRecursive(ref i_NumOfRows, 0, 'A', 1, i_NumOfRows);
        }
        private static void printTreeRecursive(ref int i_NumberOfLines, int i_CurrentLineNumber, char i_LastPrintedChar, int i_LastPrintedNumber, int i_MiddleTreePosition)
        {
            if (i_LastPrintedChar == 'Z')
            {
                i_LastPrintedChar = 'A';
            }

            if (i_LastPrintedNumber == 10)
            {
                i_LastPrintedNumber = 1;
            }

            if (i_CurrentLineNumber + 1 == i_NumberOfLines - 1)
            {
                printTrunkOfTree(i_MiddleTreePosition, i_LastPrintedNumber, i_LastPrintedChar);
            }
            else
            {
                printRowInTree(i_LastPrintedNumber, i_LastPrintedChar, i_NumberOfLines, i_CurrentLineNumber);
                printTreeRecursive(ref i_NumberOfLines, ++i_CurrentLineNumber, ++i_LastPrintedChar, i_LastPrintedNumber, i_MiddleTreePosition);
            }
        }
        private static void printRowInTree(int i_LastPrintedNumber, char i_LastPrintedChar, int i_NumberOfLines, int i_CurrentLineNumber)
        {
            Console.Write("{0}", i_LastPrintedChar);
            printSpaces(i_NumberOfLines - i_CurrentLineNumber - 1);
            printNumbersInRow((i_CurrentLineNumber * 2) + 1, ref i_LastPrintedNumber);
            Console.WriteLine();
        }
        private static void printTrunkOfTree(int i_MiddleTreePosition, int i_LastPrintedNumber, char i_LastPrintedChar)
        {
            i_MiddleTreePosition -= 2;
            Console.Write("{0} ", i_LastPrintedChar);
            printSpaces(i_MiddleTreePosition);
            Console.WriteLine("|{0}|", i_LastPrintedNumber);
            Console.WriteLine();
            Console.Write("{0} ", ++i_LastPrintedChar);
            printSpaces(i_MiddleTreePosition);
            Console.WriteLine("|{0}|", i_LastPrintedNumber);
        }
        private static void printSpaces(int i_Count)
        {
            if (i_Count <= 0)
            {
                return;
            }

            Console.Write("  ");
            printSpaces(i_Count - 1);
        }

        private static void printNumbersInRow(int i_AmountToPrintInRow, ref int i_NumberToStartFrom)
        {
            for (int i = 0; i < i_AmountToPrintInRow; i++)
            {
                Console.Write("{0} ", i_NumberToStartFrom);
                ++i_NumberToStartFrom;
                if (i_NumberToStartFrom == 10)
                {
                    i_NumberToStartFrom = 1;
                }
            }

            Console.WriteLine();
        }
    }
}
