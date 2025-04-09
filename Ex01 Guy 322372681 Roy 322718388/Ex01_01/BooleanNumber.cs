using System;
using System.Management.Instrumentation;


namespace Ex01_01
{
    public class BooleanNumber
    {
        private int[] m_myNumberInBoolean = new int[7];     //NTS - 7 is a magic number
        private int m_Length = 7;
        private int m_decimalValue = 0;
        private int m_ShiftsBetweenOnesAndZeros = 0;
        private string m_myNumberInString = "";

        protected static int[] s_LongestOnesSequence = new int[2];      // Array of 2 int: [0] for value, [1] for index,

        protected static int[] s_MostOnesInNumber = new int[2];         // need to check with GuyRo if we could use variables like Tuple

        protected static int s_NumberOfOnesInAllNumbers = 0;
        protected static float s_AvarageValueOfNumbersInDecimal = 0;
        public static BooleanNumber Parse(string i_number)
        {
            BooleanNumber result = new BooleanNumber();
            result.m_Length = i_number.Length;
            int i = 0;
            foreach (char c in i_number)
            {
                result.m_myNumberInBoolean[i++] = c - '0';
            }
            result.m_myNumberInString = i_number;
            return result;
        } 
        public int[] GetMyNumberInBoolean()
        {
            return m_myNumberInBoolean;
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
        public static int[] GetLongestOnesSequence()
        {
            return s_LongestOnesSequence;
        }
        public static int[] GetMostOnesInNumber()
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
        public void CalculateNumberStatistics()
        {
            calculateDecimalValue();
            calculateShiftsOfOnesAndZeros();
            countNumberOfOnes();
            countSequenceOfOnes();
        }
        private void calculateDecimalValue()
        {
            for (int i = 0; i < m_Length; ++i)
            {
                m_decimalValue += (int)(m_myNumberInBoolean[i] * Math.Pow(2, m_Length - i - 1));        // NTS - why explicit convertion here?
            }
        }
        private void calculateShiftsOfOnesAndZeros()
        {
            int currentDigit = m_myNumberInBoolean[0];
            for (int i = 1; i < m_Length; ++i)
            {
                if (currentDigit != m_myNumberInBoolean[i])
                {
                    ++m_ShiftsBetweenOnesAndZeros;
                }

                currentDigit = m_myNumberInBoolean[i];
            }
        }
        private void countNumberOfOnes()
        {
            int numberOfOnesOnCurrentNumber = 0;
            for (int i = 0; i < m_Length; ++i)
            {
                if (m_myNumberInBoolean[i] == 1)
                {
                    ++numberOfOnesOnCurrentNumber;
                }

            }

            s_MostOnesInNumber[0] = Math.Max(s_MostOnesInNumber[0], numberOfOnesOnCurrentNumber);
            s_NumberOfOnesInAllNumbers += numberOfOnesOnCurrentNumber;
        }

        private void countSequenceOfOnes()      //  NTS - make readable lol
        {
            int currentSequenceOfOnes = m_myNumberInBoolean[0];
            int numberMaxSequenceOfOnes = m_myNumberInBoolean[0];

            for (int i = 0; i < m_Length; ++i)
            {
                if (m_myNumberInBoolean[i] != 1)
                {
                    continue;
                }

                while (m_myNumberInBoolean[i] != 0)
                {
                    if (i != 6)
                    { 
                        currentSequenceOfOnes++;
                    }
                    else
                    {
                        break;
                    }

                    ++i;
                }

                numberMaxSequenceOfOnes = Math.Max(numberMaxSequenceOfOnes, currentSequenceOfOnes);
            }

            s_LongestOnesSequence[0] = Math.Max(s_LongestOnesSequence[0], numberMaxSequenceOfOnes);
        }

        public static void CalculateAverageDecimalValues(BooleanNumber[] i_arrayOfBooleanNumbers)
        {
            foreach (BooleanNumber currentBool in i_arrayOfBooleanNumbers)
            {
                s_AvarageValueOfNumbersInDecimal += currentBool.m_decimalValue;
            }
            s_AvarageValueOfNumbersInDecimal /= 4;
        }

        public static void SortArrayDecendingByDecimalValues(BooleanNumber[] i_arrayOfBooleanNumbers)
        {
            for (int i = 0; i < i_arrayOfBooleanNumbers.Length; i++)
            {
                for (int j = i + 1; j < i_arrayOfBooleanNumbers.Length; j++)
                {
                    if (i_arrayOfBooleanNumbers[i].m_decimalValue < i_arrayOfBooleanNumbers[j].m_decimalValue)
                    {
                        //  NTS - can define a BolleanNumber dedicated swap
                        BooleanNumber temp = i_arrayOfBooleanNumbers[i];
                        i_arrayOfBooleanNumbers[i] = i_arrayOfBooleanNumbers[j];
                        i_arrayOfBooleanNumbers[j] = temp;
                    }
                }
            }
        }
    }

}
