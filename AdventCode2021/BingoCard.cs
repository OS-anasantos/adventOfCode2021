namespace AdventCode2021 {
    public class BingoCard {
        private const string MARKED = "x";

        public string[][] Card = new string[][] {
                new string[5],
                new string[5],
                new string[5],
                new string[5],
                new string[5]
         };

        /// <summary>
        /// Initializes a bingo card
        /// </summary>
        /// <param name="cardData">Card data</param>
        public void InitializeCard(String[] cardData) {
            
            for (int i = 0; i < cardData.Length; i++) {
                InitializeCardLine(cardData[i], i);
            }

        }

        /// <summary>
        /// Initializes a car line
        /// </summary>
        /// <param name="line">Line data</param>
        /// <param name="lineNumber">Line number</param>
        public void InitializeCardLine(String line, int lineNumber) {
            String[] lineNumbers = line.Split(' ');
            lineNumbers = CleanExtraSpace(lineNumbers);

            String[] cardLine = Card[lineNumber];

            for (int i = 0; i < cardLine.Length; i++) {
                cardLine[i] = lineNumbers[i];
            }

        }

        /// <summary>
        /// Removes any extra space 
        /// </summary>
        /// <param name="lineNumbers">Line</param>
        /// <returns>All line numbers without extra spaces</returns>
        /// <exception cref="NotImplementedException"></exception>
        private string[] CleanExtraSpace(string[] lineNumbers) {
            return lineNumbers.ToList().FindAll(e => e != String.Empty).ToArray();
        }

        /// <summary>
        /// Checks if any of the lines is full
        /// </summary>
        /// <returns>True if it is, false otherwise</returns>
        public Boolean HasAnyLineFull() {
            foreach (var line in Card) {
                String cardLine = String.Join(String.Empty, line);

                if ("xxxxx" == cardLine) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Return is a column is full
        /// </summary>
        /// <returns>True if it is, false otherwise</returns>
        public Boolean HasAnyColumnFull() {
            for (int columnIndex = 0; columnIndex < Card.Length; columnIndex++) {

                String column = String.Empty;

                for (int line = 0; line < Card.Length; line++) {
                    column += Card[line][columnIndex];
                }

                if ("xxxxx" == column) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Marks a particular number in a card 
        /// </summary>
        /// <param name="number">Number to be marked</param>
        public void MarkNumber(String number) {
            for (int line = 0; line < Card.Length; line++) {
                for (int column = 0; column < Card.Length; column++) {
                    if (Card[line][column] == number) {
                        Card[line][column] = MARKED;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the sum of every unmarked value in the card
        /// </summary>
        /// <returns>Sum of every unmarked value in the card</returns>
        public int CalculateUnmarkedSum() {

            int sum = 0;

            foreach (var line in Card) {
                foreach (var value in line) {
                    if (value == MARKED) {
                        continue;
                    } else {
                        sum += Int32.Parse(value);
                    }
                }
            }

            return sum;
        }
    }
}
