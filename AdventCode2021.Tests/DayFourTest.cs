using System;
using NUnit.Framework;

namespace AdventCode2021.Tests {
    public class DayFourTest {

        BinaryDiagnostic bd = new BinaryDiagnostic(@"C:\Users\nrt\source\repos\AdventCode2021\AdventCode2021.Tests\resource\DayFourTest.txt");
        BingoCard bingoCard = new BingoCard();

        [Test]
        public void InitializeCardTest() {

            String[] cardData = new String[] {
                "26 68  3 95 59",
                "40 88 50 22 48",
                "75 67  8 64  6",
                "29  2 73 78  5",
                "49 25 80 89 96"
            };

            
            bingoCard.InitializeCard(cardData);
            string[][] card = bingoCard.Card;
            Assert.AreEqual("78", card[3][3]);
        }

        [Test]
        public void HasLineFullTest() {

            String[] cardData = new String[] {
                "26 68  3 x 59",
                "x x 50 22 48",
                "75 67  x 64  6",
                "29  2 73 x  5",
                "x x x x x"
            };

            bingoCard.InitializeCard(cardData);
            Assert.IsTrue(bingoCard.HasAnyLineFull());
        }

        [Test]
        public void HasLineEmptyTest() {
            String[] cardData = new String[] {
                "26 68  3 x 59",
                "x x 50 22 48",
                "75 67  x 64  6",
                "29  2 73 x  5",
                "x x 4 x x"
            };

            bingoCard.InitializeCard(cardData);
            Assert.IsFalse(bingoCard.HasAnyLineFull());
        }

        [Test]
        public void HasColumnFullTest() {

            String[] cardData = new String[] {
                "x 68  3 x 59",
                "40 x 50 x 48",
                "75 67  x x  6",
                "29  2 73 x  5",
                "49 25 80 x x"
            };


            bingoCard.InitializeCard(cardData);
            Assert.IsTrue(bingoCard.HasAnyColumnFull());
        }

        [Test]
        public void HasColumnEmptyTest() {
            String[] cardData = new String[] {
                "x 68  3 x 59",
                "40 x 50 x 48",
                "75 67  x x  6",
                "29  2 73  3  5",
                "49 25 80 x x"
            };


            bingoCard.InitializeCard(cardData);
            Assert.IsFalse(bingoCard.HasAnyColumnFull());
        }

        [Test]
        public void BingoInitializationTest() {
            Bingo bingo = new Bingo(@"C:\Users\nrt\source\repos\AdventCode2021\AdventCode2021.Tests\resource\DayFourTest.txt");

            Assert.AreEqual(3, bingo.Cards.Count);
        }

        [Test]
        public void MarkNumberTest() {

            String[] cardData = new String[] {
                "26 68  3 95 59",
                "40 88 50 22 48",
                "75 67  8 64  6",
                "29  2 73 78  5",
                "49 25 80 89 96"
            };


            bingoCard.InitializeCard(cardData);
            bingoCard.MarkNumber("89");

            Assert.AreEqual("x", bingoCard.Card[4][3]);
        }

        [Test]
        public void CalculateUnmarkedSumTest() {

            String[] cardData = new String[] {
                "x x x x x",
                "10 16 15  x 19",
                "18  8 x 26 20",
                "22 x 13  6  x",
                "x  x 12  3  x"
            };


            bingoCard.InitializeCard(cardData);
            int sum = bingoCard.CalculateUnmarkedSum();

            Assert.AreEqual(188, sum);
        }

        [Test]
        public void PlayBingoTest() {

            Bingo bingo = new Bingo(@"C:\Users\nrt\source\repos\AdventCode2021\AdventCode2021.Tests\resource\DayFourTest.txt");

            int res = bingo.PlayBingo();

            Assert.AreEqual(4512, res);
        }

        [Test]
        public void LastBingoTest() {

            Bingo bingo = new Bingo(@"C:\Users\nrt\source\repos\AdventCode2021\AdventCode2021.Tests\resource\DayFourTest.txt");

            int res = bingo.LastBingo();

            Assert.AreEqual(1924, res);
        }
    }
}
