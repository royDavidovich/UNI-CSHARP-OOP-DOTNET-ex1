using System;


namespace Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            int numbersToRead = 4;
            string[] numbersFromUser = ConsoleTalker.ReceiveBooleanNumbersFromUser(numbersToRead);
            BooleanNumber[] arrayOfBooleanNumbers = new BooleanNumber[4];
            for(int i = 0; i < numbersToRead; ++i)
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
