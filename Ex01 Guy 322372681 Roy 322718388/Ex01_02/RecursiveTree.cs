using System;

namespace Ex01_02
{
    public class RecursiveTree
    {
        public static void PrintTree(int i_NumOfRows)
        {
            printTreeRecursive(ref i_NumOfRows, 0, 'A', 1, i_NumOfRows);
        }
        private static void printTreeRecursive(ref int i_NumberOfLines, int i_CurrentLineNumber, char i_lastPrintedChar, int i_lastPrintedNumber, int i_MiddleTreePosition)
        {
            if (i_lastPrintedChar == 'Z')
            {
                i_lastPrintedChar = 'A';
            }
            if (i_lastPrintedNumber == 10)
            {
                i_lastPrintedNumber = 1;
            }
            if (i_CurrentLineNumber + 1 == i_NumberOfLines - 1)
            {
                printTrunkOfTree(i_MiddleTreePosition, i_lastPrintedNumber, i_lastPrintedChar);
            }
            else
            {
                printRowInTree(i_lastPrintedNumber, i_lastPrintedChar, i_NumberOfLines, i_CurrentLineNumber);
                printTreeRecursive(ref i_NumberOfLines, ++i_CurrentLineNumber, ++i_lastPrintedChar, i_lastPrintedNumber, i_MiddleTreePosition);
            }
        }
        private static void printRowInTree(int i_lastPrintedNumber, char i_lastPrintedChar, int i_NumberOfLines, int i_CurrentLineNumber)
        {
            Console.Write("{0}", i_lastPrintedChar);
            printSpaces(i_NumberOfLines - i_CurrentLineNumber - 1);
            printNumbersInRow((i_CurrentLineNumber * 2) + 1, ref i_lastPrintedNumber);
            Console.WriteLine();
        }
        private static void printTrunkOfTree(int i_MiddleTreePosition, int i_lastPrintedNumber, char i_lastPrintedChar)
        {
            i_MiddleTreePosition -= 2;
            Console.Write("{0} ", i_lastPrintedChar);
            printSpaces(i_MiddleTreePosition);
            Console.WriteLine("|{0}|", i_lastPrintedNumber);
            Console.WriteLine();
            Console.Write("{0} ", ++i_lastPrintedChar);
            printSpaces(i_MiddleTreePosition);
            Console.WriteLine("|{0}|", i_lastPrintedNumber);
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