using System;

namespace Ex01_05
{
    public class NumberWithStatistics
    {
        string m_NumberAsString = "";
        int m_DigitsSmallerThanFirstDigit = 0;
        int m_DigitsDivisibleBy3 = 0;
        int m_DifferenceBetweenLargestAndSmallestDigits = 0;
        char m_MostFrequentDigit = '0';
        int m_FrequencyOfMostCommonDigit = 0;
        

        public NumberWithStatistics(string i_number)
        {
            m_NumberAsString = i_number;
        }
        public string GetNumberAsString()
        {
            return m_NumberAsString;
        }
        public int GetDigitsSmallerThanFirstDigit()
        {
            return m_DigitsSmallerThanFirstDigit;
        }
        public int GetDigitsDivisibleBy3()
        {
            return m_DigitsDivisibleBy3;
        }
        public int GetDifferenceBetweenLargestAndSmallestDigits()
        {
            return m_DifferenceBetweenLargestAndSmallestDigits;
        }
        public char GetMostFrequentDigit()
        {
            return m_MostFrequentDigit;
        }
        public int GetFrequencyOfMostFrequentDigit()
        {
            return m_FrequencyOfMostCommonDigit;
        }
        public void CalculateStatisticsOnNumber()
        {
            howManyNumbersAreSmallerThanFirstDigit();
            howManyNumbersDivisibleBy3();
            differenceFromLargestDigitToSmallestDigit();
            mostCommonDigitAndNumberOfAppereances();
        }
        private void howManyNumbersAreSmallerThanFirstDigit()
        {
            char firstDigit = m_NumberAsString[0];
            for (int i = 1; i < m_NumberAsString.Length; ++i)
            {
                if (char.GetNumericValue(m_NumberAsString[i]) < char.GetNumericValue(firstDigit))
                {
                    m_DigitsSmallerThanFirstDigit++;
                }
            }
        }
        private void differenceFromLargestDigitToSmallestDigit()
        {
            int maxDigit = -1; //init max as a number lesser then the possible digit
            int minDigit = 10; //init min as a number larger then digit possible
            for(int i = 0; i < m_NumberAsString.Length; ++i)
            {
                maxDigit = (int)Math.Max((double)char.GetNumericValue(m_NumberAsString[i]), (double)maxDigit);
                minDigit = (int)Math.Min((double)char.GetNumericValue(m_NumberAsString[i]), (double)minDigit);
            }
            m_DifferenceBetweenLargestAndSmallestDigits = maxDigit - minDigit;
        }
        private void mostCommonDigitAndNumberOfAppereances()
        {
            string uniqueDigits = "0123456789";
            string numberCopy = m_NumberAsString;
            foreach (char d in uniqueDigits)
            {
                //count the difference from the length of the array, and the length of the array without the current digit
                int count = numberCopy.Length - numberCopy.Replace(d.ToString(), "").Length;
                if (count > m_FrequencyOfMostCommonDigit)
                {
                    m_FrequencyOfMostCommonDigit = count;
                    m_MostFrequentDigit = d;
                }
            }
        }
        private void howManyNumbersDivisibleBy3()
        {
            for (int i = 0; i < m_NumberAsString.Length; ++i)
            {
                if (char.GetNumericValue(m_NumberAsString[i]) % 3 == 0)
                {
                    m_DigitsDivisibleBy3++;
                }
            }
        }

    }
}
