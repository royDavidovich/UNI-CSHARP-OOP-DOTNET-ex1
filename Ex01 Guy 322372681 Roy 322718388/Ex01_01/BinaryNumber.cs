using System;
using System.Management.Instrumentation;


namespace Ex01_01
{
   
    public class BinaryNumber
    {
        public const int k_NumOfDigits = 7;

        private int m_Length = k_NumOfDigits;
        private int m_decimalValue = 0;
        private int m_ShiftsBetweenOnesAndZeros = 0;
        private string m_myNumberInString = "";

        protected static int s_LongestOnesSequence = 0;
        protected static string s_NumberWithLongestOnesSequenceAsBinary = "";

        protected static int s_MostOnesInNumber =    0;
        protected static string s_NumberWithMostOnesAsBinary = "";
        protected static int s_NumberWithMostOnesAsDecimal = 0;


        protected static int s_NumberOfOnesInAllNumbers = 0;
        protected static float s_AvarageValueOfNumbersInDecimal = 0;
        public static BinaryNumber Parse(string i_number, int index)
        {
            BinaryNumber result = new BinaryNumber();
            result.m_Length = i_number.Length;
            result.m_myNumberInString = i_number;
            return result;
        } 
        public string GetMyNumberInString()
        {
            return m_myNumberInString;
        }
        public int GetLength()
        {
            return m_Length;
        }
        public int GetDecimalValue()
        {
            return m_decimalValue;
        }
        public int GetShiftsBetweenOnesAndZeros()
        {
            return m_ShiftsBetweenOnesAndZeros;
        }
        public static int GetLongestOnesSequence()
        {
            return s_LongestOnesSequence;
        }
        public static string GetNumberWithLongestOneSequence()
        {
            return s_NumberWithLongestOnesSequenceAsBinary;
        }
        public static int GetMostOnesInNumber()
        {
            return s_MostOnesInNumber;
        }
        public static int GetNumberOfOnesInAllNumbers()
        {
            return s_NumberOfOnesInAllNumbers;
        }
        public int GetDecimalNumber()
        {
            return m_decimalValue;
        }
        public static float GetAverageDecimalValue()
        {
            return s_AvarageValueOfNumbersInDecimal;
        }
        public static string GetNumberWithMostOnesAsBinary()
        {
            return s_NumberWithMostOnesAsBinary;
        }
        public static int GetNumberWithMostOnesAsDecimal()
        {
            return s_NumberWithMostOnesAsDecimal;
        }
        public void CalculateNumberStatistics()
        {
            calculateDecimalValue();
            calculateShiftsOfOnesAndZeros();
            countNumberOfOnes();
            calculateLongestSequenceOfOnes();
        }
        public static void CalculateAverageDecimalValues(BinaryNumber[] i_arrayOfBinaryNumbers)
        {
            foreach (BinaryNumber currentBool in i_arrayOfBinaryNumbers)
            {
                s_AvarageValueOfNumbersInDecimal += currentBool.m_decimalValue;
            }
            s_AvarageValueOfNumbersInDecimal /= 4;
        }
        public static void SortArrayDecendingByDecimalValues(BinaryNumber[] i_arrayOfBinaryNumbers)
        {
            for (int i = 0; i < i_arrayOfBinaryNumbers.Length; i++)
            {
                for (int j = i + 1; j < i_arrayOfBinaryNumbers.Length; j++)
                {
                    if (i_arrayOfBinaryNumbers[i].m_decimalValue < i_arrayOfBinaryNumbers[j].m_decimalValue)
                    {
                        swap(ref i_arrayOfBinaryNumbers[i], ref i_arrayOfBinaryNumbers[j]);
                    }
                }
            }
        }
        private void calculateDecimalValue()
        {
            int j = 0;
            foreach (char c in m_myNumberInString)
            {
                int currentDigit = (int)char.GetNumericValue(c);
                m_decimalValue += (int)((currentDigit) * Math.Pow(2, m_Length - (j++) - 1));
            }  
        }
        private void calculateShiftsOfOnesAndZeros()
        {
            int currentDigit = (int)char.GetNumericValue(m_myNumberInString[0]);
            for (int i = 1; i < m_myNumberInString.Length; i++)
            {
                int digit = (int)char.GetNumericValue(m_myNumberInString[i]);
                if (currentDigit != digit)
                {
                    ++m_ShiftsBetweenOnesAndZeros;
                }
                currentDigit = digit;
            }
        }
        private void countNumberOfOnes()
        {
            int numberOfOnesOnCurrentNumber = 0;
            for(int i = 0; i < m_Length; i++)
            {
                int currentDigit = (int)char.GetNumericValue(m_myNumberInString[i]);
                if (currentDigit == 1)
                {
                    ++numberOfOnesOnCurrentNumber;
                }
            }
            updateNumberWithMostOnes(numberOfOnesOnCurrentNumber);
        }
        private void updateNumberWithMostOnes(int i_numberOfOnesOnCurrentNumber)
        {
            if (i_numberOfOnesOnCurrentNumber == Math.Max(s_MostOnesInNumber, i_numberOfOnesOnCurrentNumber))
            {
                s_MostOnesInNumber = i_numberOfOnesOnCurrentNumber;
                s_NumberWithMostOnesAsBinary = m_myNumberInString;
                s_NumberWithMostOnesAsDecimal = m_decimalValue;
            }

            s_NumberOfOnesInAllNumbers += i_numberOfOnesOnCurrentNumber;
        }
        private void calculateLongestSequenceOfOnes()     
        {
            int currentSequenceOfOnes = 0;
            int numberMaxSequenceOfOnes = 0;
            int currentDigit = 0;
            for (int i = 0; i < m_Length; ++i)
            {
                currentDigit = (int)char.GetNumericValue(m_myNumberInString[i]);
                if (currentDigit != 1)
                {
                    continue;
                }
                while (currentDigit != 0)
                {
                    currentSequenceOfOnes++;
                    if (++i == 7)
                        break;
                    currentDigit = (int)char.GetNumericValue(m_myNumberInString[i]);              
                }
                numberMaxSequenceOfOnes = Math.Max(numberMaxSequenceOfOnes, currentSequenceOfOnes);
                currentSequenceOfOnes = 0;                
            }
                updateNumberWithLongestSequenceOfOnes(numberMaxSequenceOfOnes);
        }
        private void updateNumberWithLongestSequenceOfOnes(int i_numberMaxSequenceOfOnes)
        {
            if (i_numberMaxSequenceOfOnes == Math.Max(s_LongestOnesSequence, i_numberMaxSequenceOfOnes))
            {
                s_LongestOnesSequence = i_numberMaxSequenceOfOnes;
                s_NumberWithLongestOnesSequenceAsBinary = m_myNumberInString;
            }
        }
        private static void swap(ref BinaryNumber io_First, ref BinaryNumber io_Second)
        {
            BinaryNumber temp = io_First;
            io_First = io_Second;
            io_Second = temp;
        }
    }

}
