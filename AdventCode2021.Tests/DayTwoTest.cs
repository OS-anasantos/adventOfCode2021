using NUnit.Framework;

namespace AdventCode2021.Tests {
    public class DayTwoTest {

        private Submarine submarine;

        [SetUp]
        public void Setup() {
            submarine = new Submarine();
        }

        [Test]
        public void Test1() {
            submarine.FollowDirections("forward 5");
            Assert.AreEqual(5, submarine.HorizontalPosition);
            Assert.AreEqual(0, submarine.DepthPosition);
            Assert.AreEqual(0, submarine.Aim);

            submarine.FollowDirections("down 5");
            Assert.AreEqual(5, submarine.HorizontalPosition);
            Assert.AreEqual(0, submarine.DepthPosition);
            Assert.AreEqual(5, submarine.Aim);

            submarine.FollowDirections("forward 8");
            Assert.AreEqual(13, submarine.HorizontalPosition);
            Assert.AreEqual(40, submarine.DepthPosition);
            Assert.AreEqual(5, submarine.Aim);

            submarine.FollowDirections("up 3");
            Assert.AreEqual(2, submarine.Aim);

            submarine.FollowDirections("down 8");
            Assert.AreEqual(10, submarine.Aim);

            submarine.FollowDirections("forward 2");
            Assert.AreEqual(15, submarine.HorizontalPosition);
            Assert.AreEqual(60, submarine.DepthPosition);

            Assert.AreEqual(900, submarine.HorizontalPosition * submarine.DepthPosition);
        }
    }
}