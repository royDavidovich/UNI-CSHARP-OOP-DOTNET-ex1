using System;
using System.Management.Instrumentation;


namespace Ex01_01
{
   
    public class BinaryNumber
    {
        public const int k_NumOfDigits = 7;

        private int m_Length = k_NumOfDigits;
        private int M_decimalValue = 0;
        private int m_ShiftsBetweenOnesAndZeros = 0;
        private string m_MyNumberInString = "";

        protected static int s_LongestOnesSequence = 0;
        protected static string s_NumberWithLongestOnesSequenceAsBinary = "";

        protected static int s_MostOnesInNumber =    0;
        protected static string s_NumberWithMostOnesAsBinary = "";
        protected static int s_NumberWithMostOnesAsDecimal = 0;


        protected static int s_NumberOfOnesInAllNumbers = 0;
        protected static float s_AvarageValueOfNumbersInDecimal = 0;
        public static BinaryNumber Parse(string i_Number, int index)
        {
            BinaryNumber result = new BinaryNumber();

            result.m_Length = i_Number.Length;
            result.m_MyNumberInString = i_Number;

            return result;
        } 
        public string GetMyNumberInString()
        {
            return m_MyNumberInString;
        }
        public int GetLength()
        {
            return m_Length;
        }
        public int GetDecimalValue()
        {
            return M_decimalValue;
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
            return M_decimalValue;
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
        public static void CalculateAverageDecimalValues(BinaryNumber[] i_ArrayOfBinaryNumbers)
        {
            foreach (BinaryNumber currentBool in i_ArrayOfBinaryNumbers)
            {
                s_AvarageValueOfNumbersInDecimal += currentBool.M_decimalValue;
            }

            s_AvarageValueOfNumbersInDecimal /= 4;
        }
        public static void SortArrayDecendingByDecimalValues(BinaryNumber[] i_ArrayOfBinaryNumbers)
        {
            for (int i = 0; i < i_ArrayOfBinaryNumbers.Length; i++)
            {
                for (int j = i + 1; j < i_ArrayOfBinaryNumbers.Length; j++)
                {
                    if (i_ArrayOfBinaryNumbers[i].M_decimalValue < i_ArrayOfBinaryNumbers[j].M_decimalValue)
                    {
                        swap(ref i_ArrayOfBinaryNumbers[i], ref i_ArrayOfBinaryNumbers[j]);
                    }
                }
            }
        }
        private void calculateDecimalValue()
        {
            int j = 0;

            foreach (char c in m_MyNumberInString)
            {
                int currentDigit = (int)char.GetNumericValue(c);
                M_decimalValue += (int)((currentDigit) * Math.Pow(2, m_Length - (j++) - 1));
            }  
        }
        private void calculateShiftsOfOnesAndZeros()
        {
            int currentDigit = (int)char.GetNumericValue(m_MyNumberInString[0]);
            for (int i = 1; i < m_MyNumberInString.Length; i++)
            {
                int digit = (int)char.GetNumericValue(m_MyNumberInString[i]);
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
                int currentDigit = (int)char.GetNumericValue(m_MyNumberInString[i]);
                if (currentDigit == 1)
                {
                    ++numberOfOnesOnCurrentNumber;
                }
            }

            updateNumberWithMostOnes(numberOfOnesOnCurrentNumber);
        }
        private void updateNumberWithMostOnes(int i_NumberOfOnesOnCurrentNumber)
        {
            if (i_NumberOfOnesOnCurrentNumber == Math.Max(s_MostOnesInNumber, i_NumberOfOnesOnCurrentNumber))
            {
                s_MostOnesInNumber = i_NumberOfOnesOnCurrentNumber;
                s_NumberWithMostOnesAsBinary = m_MyNumberInString;
                s_NumberWithMostOnesAsDecimal = M_decimalValue;
            }

            s_NumberOfOnesInAllNumbers += i_NumberOfOnesOnCurrentNumber;
        }
        private void calculateLongestSequenceOfOnes()     
        {
            int currentSequenceOfOnes = 0;
            int numberMaxSequenceOfOnes = 0;
            int currentDigit = 0;
            for (int i = 0; i < m_Length; ++i)
            {
                currentDigit = (int)char.GetNumericValue(m_MyNumberInString[i]);
                if (currentDigit != 1)
                {
                    continue;
                }

                while (currentDigit != 0)
                {
                    currentSequenceOfOnes++;
                    if (++i == 7)
                    {
                        break;
                    }

                    currentDigit = (int)char.GetNumericValue(m_MyNumberInString[i]);              
                }

                numberMaxSequenceOfOnes = Math.Max(numberMaxSequenceOfOnes, currentSequenceOfOnes);
                currentSequenceOfOnes = 0;                
            }

                updateNumberWithLongestSequenceOfOnes(numberMaxSequenceOfOnes);
        }
        private void updateNumberWithLongestSequenceOfOnes(int i_NumberMaxSequenceOfOnes)
        {
            if (i_NumberMaxSequenceOfOnes == Math.Max(s_LongestOnesSequence, i_NumberMaxSequenceOfOnes))
            {
                s_LongestOnesSequence = i_NumberMaxSequenceOfOnes;
                s_NumberWithLongestOnesSequenceAsBinary = m_MyNumberInString;
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
