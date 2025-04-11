using System;

namespace Ex01_02
{
    public class RecursiveTree
    {
        public static void PrintTree()
        {
            int numOfRows = 15;
            printTreeRecursive(ref numOfRows, 0, 'A', 1, numOfRows);
        }

        private static void printTreeRecursive(ref int i_numberOfLines, int i_currentLineNumber, char i_lastPrintedChar, int i_lastPrintedNumber, int i_middleTreePosition)
        {
            if (i_lastPrintedChar == 'Z')
            {
                i_lastPrintedChar = 'A';
            }
            if (i_lastPrintedNumber == 10)
            {
                i_lastPrintedNumber = 1;
            }

            if (i_currentLineNumber + 1 == i_numberOfLines)
            {
                i_middleTreePosition -= 2;
                Console.Write("{0} ", i_lastPrintedChar);
                PrintSpaces(i_middleTreePosition);
                Console.WriteLine("|{0}|", i_lastPrintedNumber);
                Console.Write("{0} ", ++i_lastPrintedChar);
                PrintSpaces(i_middleTreePosition);
                Console.WriteLine("|{0}|", i_lastPrintedNumber);
            }
            else
            {
                Console.Write("{0}", i_lastPrintedChar);
                PrintSpaces(i_numberOfLines - i_currentLineNumber - 1);
                PrintNumbersInRow((i_currentLineNumber * 2) + 1, ref i_lastPrintedNumber);
                printTreeRecursive(ref i_numberOfLines, ++i_currentLineNumber, ++i_lastPrintedChar, i_lastPrintedNumber, i_middleTreePosition);
            }
        }

        static void PrintSpaces(int count)
        {
            if (count <= 0)
            {
                return;
            }
            Console.Write("  ");
            PrintSpaces(count - 1);
        }

        static void PrintNumbersInRow(int i_amountToPrintInRow, ref int i_numberToStartFrom)
        {
            for (int i = 0; i < i_amountToPrintInRow; i++)
            {
                Console.Write("{0} ", i_numberToStartFrom);
                ++i_numberToStartFrom;
                if (i_numberToStartFrom == 10)
                {
                    i_numberToStartFrom = 1;
                }
            }
            Console.WriteLine();
        }
    }
}