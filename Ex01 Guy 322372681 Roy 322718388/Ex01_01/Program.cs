using System;


namespace Ex01_01
{
    public class Program
    {
        private const int NumbersToRead = 4;
        public static void Main()
        {
            string[] numbersFromUser = ConsoleTalker.ReceiveBooleanNumbersFromUser(NumbersToRead);
            BooleanNumber[] arrayOfBooleanNumbers = new BooleanNumber[NumbersToRead];
            for(int i = 0; i < NumbersToRead; ++i)
            {
                arrayOfBooleanNumbers[i] = BooleanNumber.Parse(numbersFromUser[i]);
                arrayOfBooleanNumbers[i].CalculateNumberStatistics();
            }
            
            BooleanNumber.CalculateAverageDecimalValues(arrayOfBooleanNumbers);
            BooleanNumber.SortArrayDecendingByDecimalValues(arrayOfBooleanNumbers);
            ConsoleTalker.ShowStatistics(arrayOfBooleanNumbers);
        }
    }
}
