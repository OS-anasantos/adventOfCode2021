using System;
using NUnit.Framework;

namespace AdventCode2021.Tests {
    public class DayThreeTest {

        BinaryDiagnostic bd = new BinaryDiagnostic(@"C:\Users\nrt\source\repos\AdventCode2021\AdventCode2021.Tests\resource\DayThreeTest.txt");

        [Test]
        public void CalculateRatesTest() {
            bd.CalculateRates();
            String gamma = bd.Gamma;
            String elipson = bd.Elipson;
            String oxigen = bd.Oxigen;
            String co2 = bd.CO2; 

            Assert.NotNull(gamma);
            Assert.AreEqual("10110", gamma);
            Assert.AreEqual("01001", elipson);
            Assert.AreEqual("10111", oxigen);
            Assert.AreEqual("01010", co2);

        }

        [Test]
        public void CalculateDecimalTest() {
            string binaryGamma = "10110";
            int decimalValue = BinaryDiagnostic.CalculateDecimal(binaryGamma);

            Assert.AreEqual(22, decimalValue);
        }
        
    }
}
