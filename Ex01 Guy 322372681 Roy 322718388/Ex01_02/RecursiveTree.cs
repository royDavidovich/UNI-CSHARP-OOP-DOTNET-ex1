using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    public class RecursiveTree
    {
       
        public static void PrintTree()
        {
            printTreeRecursive(1, 'A', 1, 11);
        }

        private static void printTreeRecursive(int i_numToStartPrintFrom, char i_charToPrint, int i_numOfNumbers, int i_numOfSpaces)
        {
            if (i_charToPrint == 'A')
            {
                Console.WriteLine("A           1");
                printTreeRecursive(i_numToStartPrintFrom + 1, (char)((int)i_charToPrint + 1), i_numOfNumbers + 2, i_numOfSpaces - 2);
            }
            else
            {
                if (i_charToPrint == 'F')
                {
                    Console.WriteLine("F          |8|");   //NTS need to implement better, its to spesific
                    Console.WriteLine("G          |8|");
                }
                else
                {
                    Console.Write(i_charToPrint);
                    for (int i = 0; i < i_numOfSpaces; i++)
                    {
                        Console.Write(" ");
                    }
                    for (int i = 0; i < i_numOfNumbers; i++)
                    {
                        Console.Write(i_numToStartPrintFrom + " ");
                        i_numToStartPrintFrom = (i_numToStartPrintFrom + 1) % 10;
                        if (i_numToStartPrintFrom == 0)
                        {
                            i_numToStartPrintFrom = 1;
                        }
                    }
                    Console.Write('\n');
                    printTreeRecursive(i_numToStartPrintFrom, (char)((int)i_charToPrint + 1), i_numOfNumbers + 2, i_numOfSpaces - 2);
                }
                   
            }
            return;
        }
    }
}
