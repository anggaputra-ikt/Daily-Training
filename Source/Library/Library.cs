namespace Libraries
{
    public class Library
    {
        /// <summary>
        /// Convert Roman to Decimal
        /// </summary>
        /// <param name="input">Roman numerals</param>
        /// <returns>The number of decimal. If wrong input return 0.</returns>
        public static int RomanToDecimal(string input)
        {
            if(string.IsNullOrEmpty(input)) return 0;
            input = input.ToUpper();

            int GetCharRomanValue(char value)
            {
                if (value == 'I') return 1;
                if (value == 'V') return 5;
                if (value == 'X') return 10;
                if (value == 'L') return 50;
                if (value == 'C') return 100;
                if (value == 'D') return 500;
                if (value == 'M') return 1000;
                return 0;
            }

            int value = 0;
            int currentValue = 0;
            int nextValue = 0;
            for (var i = 0; i < input.Length; i++)
            {
                currentValue = GetCharRomanValue(input[i]);
                if ((i + 1) < input.Length)
                {
                    nextValue = GetCharRomanValue(input[i + 1]);
                    if (currentValue < nextValue)
                    {
                        value -= currentValue;
                        continue;
                    }
                }
                value += currentValue;
            }
            return value;
        }
    }
}