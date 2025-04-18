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
        public static void PrintTree(int i_numOfRows)
        {
            printTreeRecursive(ref i_numOfRows, 0, 'A', 1, i_numOfRows);
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

            if (i_currentLineNumber  == i_numberOfLines - 2)
            {
                printTreeTrunk(ref i_middleTreePosition, i_lastPrintedChar, i_lastPrintedNumber); 
            }
            else
            {
                int numOfSpacesToPrint = i_numberOfLines - i_currentLineNumber - 1;
                int amountToPrintInRow = (i_currentLineNumber * 2) + 1;

                Console.Write("{0}", i_lastPrintedChar);
                printSpaces(numOfSpacesToPrint);
                printNumbersInRow(amountToPrintInRow, ref i_lastPrintedNumber);
                Console.WriteLine();
                printTreeRecursive(ref i_numberOfLines, ++i_currentLineNumber, ++i_lastPrintedChar, i_lastPrintedNumber, i_middleTreePosition);
            }
        }
        private static void printTreeTrunk(ref int i_middleTreePosition, char i_lastPrintedChar, int i_lastPrintedNumber)
        {
            i_middleTreePosition -= 2;
            Console.Write("{0} ", i_lastPrintedChar);
            printSpaces(i_middleTreePosition);
            Console.WriteLine("|{0}|", i_lastPrintedNumber);
            Console.WriteLine();
            Console.Write("{0} ", ++i_lastPrintedChar);
            printSpaces(i_middleTreePosition);
            Console.WriteLine("|{0}|", i_lastPrintedNumber);
        }
        private static void printSpaces(int i_count)
        {
            if (i_count <= 0)
            {
                return;
            }
			
            Console.Write("  ");
            printSpaces(i_count - 1);
        }

        private static void printNumbersInRow(int i_amountToPrintInRow, ref int i_numberToStartFrom)
        {
            for (int i = 0; i < i_amountToPrintInRow; ++i)
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
