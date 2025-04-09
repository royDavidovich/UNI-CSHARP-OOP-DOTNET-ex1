using System;


namespace Ex01_01
{
    public class Program
    {
        private const int k_NumbersToRead = 4;
        public static void Main()
        {
            string[] numbersFromUser = ConsoleTalker.ReceiveBinaryNumbersFromUser(k_NumbersToRead);
            BinaryNumber[] arrayOfBinaryNumbers = new BinaryNumber[k_NumbersToRead];
            for(int i = 0; i < k_NumbersToRead; ++i)
            {
                arrayOfBinaryNumbers[i] = BinaryNumber.Parse(numbersFromUser[i], i);
                arrayOfBinaryNumbers[i].CalculateNumberStatistics();
            }
            
            BinaryNumber.CalculateAverageDecimalValues(arrayOfBinaryNumbers);
            BinaryNumber.SortArrayDecendingByDecimalValues(arrayOfBinaryNumbers);
            ConsoleTalker.ShowStatistics(arrayOfBinaryNumbers);
        }
    }
}
