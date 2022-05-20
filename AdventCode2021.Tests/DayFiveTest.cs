using System;
using AdventCode2021.Day5;
using NUnit.Framework;

namespace AdventCode2021.Tests {
    public class DayFiveTest {

        private Points points;

        [SetUp]
        public void Setup() {
            points = new Points(@"C:\Users\nrt\source\repos\AdventCode2021\AdventCode2021.Tests\resource\DayFiveTest.txt");
        }

        [Test]
        public void LineIsVerticalTest() {

            Boolean isVertical = points.IsLineHorizontalOrVertical(
                new int[] { 0, 9 },
                new int[] { 5, 9 });

            Assert.IsTrue(isVertical);
        }

        [Test]
        public void LineIsHorizontalTest() {

            Boolean isHorizontal = points.IsLineHorizontalOrVertical(
                new int[] { 7, 0 },
                new int[] { 7, 4 });

            Assert.IsTrue(isHorizontal);
        }

        [Test]
        public void LineIsDiagonalTest() {

            Boolean isHorizontal = points.IsLineHorizontalOrVertical(
                new int[] { 8, 0 },
                new int[] { 0, 8 });

            Assert.IsFalse(isHorizontal);
        }

        [Test]
        public void LinePointsTest() {

            points.AddLinePoints(
                new int[] { 0, 9 },
                new int[] { 5, 9 });

            Assert.AreEqual(6, points.Map.Count);
        }

        [Test]
        public void AddDiagonalPointsTest() {
            points.AddDiagonalPoints(
                new int[] { 0, 0 },
                new int[] { 8, 8 });

            Assert.AreEqual(9, points.Map.Count);
            Assert.IsTrue(points.Map.ContainsKey("0,0"));
            Assert.IsTrue(points.Map.ContainsKey("1,1"));
            Assert.IsTrue(points.Map.ContainsKey("2,2"));
            Assert.IsTrue(points.Map.ContainsKey("3,3"));
            Assert.IsTrue(points.Map.ContainsKey("4,4"));
            Assert.IsTrue(points.Map.ContainsKey("5,5"));
            Assert.IsTrue(points.Map.ContainsKey("6,6"));
            Assert.IsTrue(points.Map.ContainsKey("7,7"));
            Assert.IsTrue(points.Map.ContainsKey("8,8"));
        }

        [Test]
        public void AddDiagonalPointsDescendingToRightTest() {
            points.AddDiagonalPoints(
                new int[] { 2, 0 },
                new int[] { 4, 2 });

            Assert.AreEqual(3, points.Map.Count);
            Assert.IsTrue(points.Map.ContainsKey("2,0"));
            Assert.IsTrue(points.Map.ContainsKey("3,1"));
            Assert.IsTrue(points.Map.ContainsKey("4,2"));
        }

        [Test]
        public void AddDiagonalPointsAscendingToRightTest() {
            points.AddDiagonalPoints(
                new int[] { 0, 4 },
                new int[] { 4, 0 });

            Assert.AreEqual(5, points.Map.Count);
            Assert.IsTrue(points.Map.ContainsKey("0,4"));
            Assert.IsTrue(points.Map.ContainsKey("1,3"));
            Assert.IsTrue(points.Map.ContainsKey("2,2"));
            Assert.IsTrue(points.Map.ContainsKey("3,1"));
            Assert.IsTrue(points.Map.ContainsKey("4,0"));
        }

        [Test]
        public void AddDiagonalPointsDescendingToLeftTest() {
            points.AddDiagonalPoints(
                new int[] { 0, 4 },
                new int[] { 4, 0 });


            Assert.AreEqual(5, points.Map.Count);
            Assert.IsTrue(points.Map.ContainsKey("0,4"));
            Assert.IsTrue(points.Map.ContainsKey("1,3"));
            Assert.IsTrue(points.Map.ContainsKey("2,2"));
            Assert.IsTrue(points.Map.ContainsKey("3,1"));
            Assert.IsTrue(points.Map.ContainsKey("4,0"));
        }

        [Test]
        public void AddDiagonalPointsAscendingToLeftTest() {
            points.AddDiagonalPoints(
                new int[] { 2, 4 },
                new int[] { 0, 2 });

            Assert.AreEqual(3, points.Map.Count);
            Assert.IsTrue(points.Map.ContainsKey("2,4"));
            Assert.IsTrue(points.Map.ContainsKey("1,3"));
            Assert.IsTrue(points.Map.ContainsKey("0,2"));
        }

        [Test]
        public void CountIntersectionsTest() {

            points.ProcessPoints();
            int intersections = points.CountIntersections();

            points.Draw();

            Assert.AreEqual(12, intersections);

        }
    }
}
