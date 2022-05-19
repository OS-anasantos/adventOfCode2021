using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2021 {
    public class Bingo {

        public List<BingoCard> Cards;
        List<String> SortedNumbers;
        List<int> bingo = new List<int>();
        int sortedNumberBingo;

        public Bingo(String path) {
            Cards = new List<BingoCard>();
            String[] fileInput = File.ReadAllLines(path);

            SortedNumbers = fileInput[0].Split(",").ToList();
            InitializeCards(fileInput);
        }

        /// <summary>
        /// Return which card achieves Bingo first.
        /// </summary>
        /// <returns>Card number that achieves Bingo first</returns>
        public int PlayBingo() {

            foreach (var sortedNumber in SortedNumbers) {
                MarkAndCheckBingo(sortedNumber, true);

                if (bingo.Count > 0) {
                    break;
                }
            }

            int points = Cards[bingo[0]].CalculateUnmarkedSum();

            return points * sortedNumberBingo;
        }

        /// <summary>
        /// Return which card achieves Bingo last.
        /// </summary>
        /// <returns>Card number that achieves Bingo last</returns>
        public int LastBingo() {

            foreach (var sortedNumber in SortedNumbers) {
                if (bingo.Count < Cards.Count) {
                    MarkAndCheckBingo(sortedNumber, false);
                } else {
                    break;
                }
            }

            int lastBingoCardNumber = bingo.Last();
            int points = Cards[lastBingoCardNumber].CalculateUnmarkedSum();

            return points * sortedNumberBingo;
        }

        /// <summary>
        /// Marks a number and checks if Bingo was achieved
        /// </summary>
        /// <param name="number">Sorted Number</param>
        /// <param name="getFirst">Flag to return just the first to achieve bingo</param>
        private void MarkAndCheckBingo(String number, Boolean getFirst) {
            for (int cardNumber = 0; cardNumber < Cards.Count; cardNumber++) {

                if (bingo.Contains(cardNumber)) {
                    continue;
                }

                BingoCard card = Cards[cardNumber];
                card.MarkNumber(number);

                if (card.HasAnyLineFull() || card.HasAnyColumnFull()) {
                    
                    bingo.Add(cardNumber);
                    sortedNumberBingo = Int32.Parse(number);

                    if (getFirst) {
                        return;
                    }
                    
                }
            }
        }

        /// <summary>
        /// Initializes all cards
        /// </summary>
        /// <param name="fileInput">File input data</param>
        private void InitializeCards(string[] fileInput) {
            for (int line = 1; line < fileInput.Length;) {
                if (String.IsNullOrEmpty(fileInput[line])) {
                    line++;
                    continue;
                }

                BingoCard card = new BingoCard();
                for (int i = 0; i < 5; i++) {
                    card.InitializeCardLine(fileInput[line], i);
                    line++;
                }
                Cards.Add(card);
            }
        }
    }
}
