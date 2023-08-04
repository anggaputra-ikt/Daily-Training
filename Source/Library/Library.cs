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
            if (string.IsNullOrEmpty(input)) return 0;

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

            input = input.ToUpper();
            int inputLength = input.Length;

            // Return 0 if value of first char smaller than second char
            // apart from char I, X and C with input length equals 2
            if (inputLength == 2)
            {
                if (GetCharRomanValue(input[0]) < GetCharRomanValue(input[1]))
                {
                    var firstChar = input[0];
                    if (firstChar != 'I' && firstChar != 'X' && firstChar != 'C')
                    {
                        return 0;
                    }
                }
            }

            int value = 0;
            for (var i = 0; i < inputLength; i++)
            {
                int currentValue = GetCharRomanValue(input[i]);
                // Return 0 if current value greather than the previous 2 iterators,
                // with previous 1 iterator and previous 2 iterator greather than 0
                if ((i - 1) >= 0 && (i - 2) >= 0)
                {
                    if (currentValue > GetCharRomanValue(input[i - 2]))
                    {
                        return 0;
                    }
                }

                // If next iterator smaller than input length
                if ((i + 1) < inputLength)
                {
                    int nextValue = GetCharRomanValue(input[i + 1]);
                    if (currentValue < nextValue)
                    {
                        value -= currentValue;
                        continue;
                    }
                }
                value += currentValue;
            }
            // Return 0 if value greather than 4999
            if (value > 4999) return 0;
            return value;

        }

        /// <summary>
        /// Finds the distance between two words in a word list.
        /// </summary>
        /// <param name="words">List word</param>
        /// <param name="firstWord">First word</param>
        /// <param name="secondWord">Second word</param>
        /// <returns>Information about distance and direction.</returns>
        public static string ClosestStrings(List<string> words, string firstWord, string secondWord)
        {
            if (words == null) return "List words cannot be null.";
            if (words.Count < 2) return "Word members are still few to run the process.";
            if (string.IsNullOrEmpty(firstWord) || string.IsNullOrEmpty(secondWord)) return "First or second word parameter is required.";

            int firstIndex = -1;
            int secondIndex = -1;
            // Cari Index dari Kata yang ingin dibandingkan
            for (int i = 0; i < words.Count; i++)
            {
                // Mencari kata yang terdapat dalam list kata, kemudian simpan dalam variabel index
                if (words[i] == firstWord)
                {
                    firstIndex = i;
                }
                if (words[i] == secondWord)
                {
                    secondIndex = i;
                }
            }
            string direction = string.Empty;
            int distance = 0;
            if (firstIndex < 0 || secondIndex < 0)
            {
                direction = "Invalid";
                distance = -1;
            }
            else
            {
                distance = firstIndex - secondIndex;
                // Mencari arah jarak
                if (distance < 0)
                {
                    direction = "Right";
                }
                else if (distance > 0)
                {
                    direction = "Left";
                }
                else if (distance == 0)
                {
                    direction = "This";
                }
                else
                {
                    direction = "Invalid";
                }
                // Merubah jika nilai jarak minus
                distance = distance < 0 ? distance * (-1) : distance;
            }
            return $"{distance} to {direction}";
        }
    }
}