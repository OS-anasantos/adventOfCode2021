namespace AdventCode2021 {
    public class BinaryDiagnostic {

        private string[] Numbers { get; set; }
        public String Gamma { get; set; }
        public String Elipson { get; set; }
        public String Oxigen { get; set; }
        public String CO2 { get; set; }

        public readonly int NumberLength;
        public String MostCommon;

        private delegate Boolean RateDelagate(String s1, String s2);

        public BinaryDiagnostic(string path) {
            Numbers = InitializeNumbers(path);
            Gamma = String.Empty;
            Elipson = String.Empty;
            MostCommon = String.Empty;
            Oxigen = String.Empty;
            CO2 = String.Empty;
            NumberLength = Numbers == null? 0 : Numbers[0].Length;
        }

        /// <summary>
        /// Populates the Numbers array with the values indicated in the file.
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>Array with lines read</returns>
        public string[] InitializeNumbers(string path) {
            return File.ReadAllLines(path);
        }

        /// <summary>
        /// Calculates the Gamma rate.
        /// </summary>
        public void CalculateGamma() {

            for (int i = 0; i < NumberLength; i++) {
                if ("0" == MostCommon[i].ToString()) {
                    Gamma += "0";
                } else {
                    Gamma += "1";
                }
            }
            
        }

        /// <summary>
        /// Calculates the Elipson rate.
        /// </summary>
        public void CalculateElipson() {

            for (int i = 0; i < NumberLength; i++) {
                if ("0" == MostCommon[i].ToString()) {
                    Elipson += "1";
                } else {
                    Elipson += "0";
                }
            }

        }
        
        private Boolean OxigenComparasion(String s1, String s2) {
            return s1 != s2;
        }

        private Boolean CO2Comparasion(String s1, String s2) {
            return s1 == s2;
        }

        private String Calculate(RateDelagate rateDelagate) {

            List<String> numbersCopy = Numbers.ToList();

            for (int j = 0; j < NumberLength && numbersCopy.Count > 1; j++) {

                String mostCommon = GetMostCommonBitInPosition(numbersCopy, j);

                for (int i = 0; i < numbersCopy.Count && numbersCopy.Count > 1; i++) {
                    if (rateDelagate(numbersCopy[i][j].ToString(), mostCommon)) {
                        numbersCopy.RemoveAt(i);
                        i -= 1;
                    }

                }
            }

            return numbersCopy[0];

        }

        /// <summary>
        /// Calculates the Oxigen rate.
        /// </summary>
        private void CalculateOxigen() {

            RateDelagate oxigenRate = OxigenComparasion;
            Oxigen = Calculate(oxigenRate);

        }

        /// <summary>
        /// Calculates the CO2 rate
        /// </summary>
        public void CalculateCO2() {

            RateDelagate co2Rate = CO2Comparasion;
            CO2 = Calculate(co2Rate);
        }

        /// <summary>
        /// Calculates all rates.
        /// </summary>
        public void CalculateRates() {
            FindMostCommon();
            CalculateGamma();
            CalculateElipson();
            CalculateOxigen();
            CalculateCO2();
        }

        /// <summary>
        /// Returns the most common bit value for that position
        /// </summary>
        /// <param name="list">List of binary numbers</param>
        /// <param name="position">Bit position to be considered</param>
        /// <returns>Most common bit value for that position</returns>
        private String GetMostCommonBitInPosition(List<String> list, int position) {

            int countZero = 0;
            int countOne = 0;

            foreach (var number in list) {
                string bit = number[position].ToString();

                if ("1".Equals(bit)) {
                    countOne++;
                } else {
                    countZero++;
                }
            }

            if (countZero > countOne) {
                return "0";
            } else {
                return "1";
            }

        }

        /// <summary>
        /// Constructs a string with the most common bit value at each position
        /// </summary>
        private void FindMostCommon() {

            for (int i = 0; i < NumberLength; i++) {
                int countZero = 0;
                int countOne = 0;

                foreach (var number in Numbers) {
                    string bit = number[i].ToString();

                    if ("1".Equals(bit)) {
                        countOne++;
                    } else {
                        countZero++;
                    }
                }

                if (countZero > countOne) {
                    MostCommon += "0";                 
                } else {
                    MostCommon += "1";
                }
            }
        }

        /// <summary>
        /// Calculates the decimal value equivalent to the binary value given.
        /// </summary>
        /// <param name="binary">Binary value</param>
        /// <returns>Decimal value</returns>
        public static int CalculateDecimal(string binary) {

            int decimalValue = 0;
            int pow = 0;

            for (var i = binary.Length - 1; i >= 0; i--) {

                int bit = Int32.Parse(binary[i].ToString());

                decimalValue += (bit * Pow(2, pow));
                pow++;

            }

            return decimalValue;

        }

        /// <summary>
        /// Calculates the power of v to pow
        /// </summary>
        /// <param name="v">Base value</param>
        /// <param name="pow">Power</param>
        /// <returns>Power of v to pow</returns>
        private static int Pow(int v, int pow) {
            int res = 1;

            while (pow > 0) {
                res *= v;
                pow--;
            }

            return res;
        }
    }
}