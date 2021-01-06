using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorUnitTests
{
    [TestClass]
    public class CalculatorUnitTests
    {
        [TestMethod]
        public void Add_EmptyString()
        {
            string.Empty.ShouldCalculateTo(0);
        }
        [TestMethod]
        public void Add_SingleNumberShouldRerurnNumber()
        {
            "1".ShouldCalculateTo(1);
        }
        [TestMethod]
        public void Add_TwoNumbersShouldRerurnSum()
        {
            "1,2".ShouldCalculateTo(3);
        }
        [TestMethod]
        public void Add_MultipleNumbersShouldRerurnSum()
        {
            "1,2,3".ShouldCalculateTo(6);
        }
        [TestMethod]
        public void Add_NewLineAsDelimiterShouldReturnSum()
        {
            "1\n2\n3".ShouldCalculateTo(6);
        }
        [TestMethod]
        public void Add_ConsecutiveDelimitersShouldThrowException()
        {
            Assert.ThrowsException<ArgumentException>(() => new StringCalculator().Add(",,"));
           
        }
        [TestMethod]
        public void Add_CustomDelimiterShouldReturnSum()
        {
            "//;\n1;2".ShouldCalculateTo(3);
        }
        [TestMethod]
        public void Add_NegativeNumberShouldThrowException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new StringCalculator().Add("-1,2"));

        }
        [TestMethod]
        public void Add_NegativeNumberErrorMessageShouldContainNegativeNumber()
        {
            var error = Assert.ThrowsException<ArgumentOutOfRangeException>(() => new StringCalculator().Add("-1,2"));
            Assert.IsTrue(error.Message.Contains("-1"));
        }

    }
        internal static class TestHelper
        {
            public static void ShouldCalculateTo(this string input, int expected)
            {
                var item = new StringCalculator();

                Assert.AreEqual(expected, item.Add(input));
            }
        }



    
}
