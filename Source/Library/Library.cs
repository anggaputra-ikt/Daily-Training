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

        /// <summary>
        /// Enkripsi dengan mengubah total huruf menjadi hexadecimal dan membalikan hasilnya
        /// </summary>
        /// <param name="input">Adalah string</param>
        /// <returns>Mengembalikan hasil berupa string</returns>
        public static string EncryptString(string input)
        {
            string ConvertToHex(int number)
            {
                // Pembagi dari nilai dibagi 16 (base 16)
                int divide = number / 16;
                // Sisa dari hasil bagi
                int remainder = number % 16;
                string remainderHex = string.Empty;
                if (remainder == 10) remainderHex = "a";
                else if (remainder == 11) remainderHex = "b";
                else if (remainder == 12) remainderHex = "c";
                else if (remainder == 13) remainderHex = "d";
                else if (remainder == 14) remainderHex = "e";
                else if (remainder == 15) remainderHex = "f";
                return $"{(divide == 0 ? string.Empty : divide)}{(remainderHex != string.Empty ? remainderHex : remainder)}";
            }

            if (string.IsNullOrEmpty(input)) return "Input harus diisi.";
            List<char> mainChar = new List<char>();
            // Filter karakter utama
            for (int i = 0; i < input.Length; i++)
            {
                if (mainChar.Contains(char.ToLower(input[i])) == false)
                {
                    mainChar.Add(char.ToLower(input[i]));
                }
            }

            var concat = string.Empty;
            for (int i = 0; i < mainChar.Count; i++)
            {
                // Mencari karakter yang ada pada mainChar dengan string inputnya
                var findChar = input.Where(c => char.ToLower(c) == mainChar[i]);
                // Menghitung jumlah karakter yang dicari
                var findCount = findChar.Count();
                // Mengubah jumlah menjadi nilai hexadecimal
                var countToHex = ConvertToHex(findCount);
                concat += $"{mainChar[i]}{countToHex}";
            }
            // Konversi menjadi array char
            var concatToChar = concat.ToCharArray();
            // Membalik urutan array
            var reverse = concatToChar.Reverse();
            // Mengembalikan nilai menjadi string
            return string.Concat(reverse);
        }

        /// <summary>
        /// Validasi apakah input merupakan IP Address yang valid atau tidak
        /// </summary>
        /// <param name="ip"></param>
        /// <returns>Jika IP Address valid akan mengembalikan nilai 1, sebaliknya jika tidak valid akan mengembalikan nilai 0.</returns>
        public static int ValidateIPAddress(string ip)
        {
            // Cek apkah input sebuah digit
            bool IsDigit(string input)
            {
                if (input == null) return false;
                // Cek jika input berupa integer
                var check = int.TryParse(input, out var result);
                // Jika hasil bukan integer kembalikan false
                if (check == false) return false;
                return true;
            }

            // Cek apakah input adalah bagian valid
            bool IsValidPart(string input)
            {
                if (input == null) return false;
                // Jika panjang input 0 atau lebih dari 3 maka kembalikan false
                if (input.Length == 0 || input.Length > 3) return false;
                // Jika input bukan digit kembalikan false
                if (IsDigit(input) == false) return false;
                // Dapatkan nilai dari input pertama
                var inputZero = char.GetNumericValue(input[0]);
                // Jika panjang input lebih dari 1 dan nilai input pertama sama dengan 0 maka kembalikan false
                if (input.Length > 1 && inputZero == 0) return false;
                return true;
            }

            // Jika input adalah null kembalikan 0
            if (ip == null) return 0;
            // Pisahkan input dengan pemisah titik '.'
            var split = ip.Split('.');
            for (int i = 0; i < split.Length; i++)
            {
                // Cek jika bagian ip adalah valid, jika tidak valid kembalikan 0
                if (IsValidPart(split[i]) == false) return 0;
            }
            return 1;
        }

        /// <summary>
        /// Mencari nilai partisi string yang seimbang dari huruf L dan R
        /// </summary>
        /// <param name="partitions"></param>
        /// <returns>Jumlah partisi yang seimbang</returns>
        public static int BalancedStringPartitions(string partitions)
        {
            // Jika string null or empty kembalikan 0
            if (string.IsNullOrEmpty(partitions)) return 0;
            // Konversi string menjadi Upper
            partitions = partitions.ToUpper();
            // Inisiasi untuk menghitung huruf L / R
            int counterL = 0;
            int counterR = 0;
            // Inisiasi untuk posisi yang akan dipisahkan
            List<int> partitionPoin = new List<int>();
            // Looping untuk mencari posisi pemisah
            for (int i = 0; i < partitions.Length; i++)
            {
                // Jika nilai i sama dengan L, maka tambah 1 dari nilai counter L
                if (partitions[i] == 'L')
                {
                    counterL++;
                }
                // Jika nilai i sama dengan L, maka tambah 1 dari nilai counter R
                if (partitions[i] == 'R')
                {
                    counterR++;
                }
                // Jika nilai counter L dan R lebih dari 0, dan nilai counter L dan R sama
                if (counterL > 0 && counterR > 0 && counterL == counterR)
                {
                    // Menambahkan nilai posisi ke dalam list,
                    // ditambah 1 agar posisi pembagi setelah nilai yang seimbang
                    partitionPoin.Add(i + 1);
                    // Reset nilai dari counter L dan r
                    counterL = 0;
                    counterR = 0;
                }
            }
            // Looping untuk menambahkan pemisah
            for (int i = 0; i < partitionPoin.Count - 1; i++)
            {
                // Menambahkan koma "," kedalam string sesuai posisinya,
                // dan ditambhkan nilai dari i karena posisi akan naik
                // karena bertambahnya nilai looping dan string
                partitions = partitions.Insert(partitionPoin[i] + i, ",");
            }
            // Memisahkan string dengan koma
            var partitionSplit = partitions.Split(",");
            // Mengembalikan jumlah partisi yang seimbang
            return partitionSplit.Count();
        }

        /// <summary>
        /// Cek karakter valid atau tidak
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Mengembalikan nilai true jika valid dan false jika tidak valid.</returns>
        public static bool IsValidCharacters(string input)
        {
            var valid = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                '!', '(', ')', '-', ',', '?', '[', ']', '_', '`', '~', ';', ':', '@', '#', '$', '%', '^', '&', '*', '+', '='};

            // Looping setiap karakter dari input
            for (int i = 0; i < input.Length; i++)
            {
                // Mencari nilai dari karakter apakah null
                var find = valid.FirstOrDefault(c => c == input[i]);
                // Jika tidak valid mengembalikan nilai false
                if (find == 0)
                {
                    return false;
                }
            }
            // Jika valid mengembalikan nilai true
            return true;
        }
    }
}