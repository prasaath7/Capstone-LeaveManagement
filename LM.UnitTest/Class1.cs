using NUnit.Framework;
using System;

namespace LM.UnitTest
{
    [TestFixture]
    public class SampleTests
    {
        [Test]
        public void Add_Empty_Returns_zero()
        {
            Calculator calc = new Calculator();
            int expectedResult = 5;
            int result = calc.Add(2,3);
            Assert.AreEqual(expectedResult, result);
        }

    }

    public class Calculator
    {
        public int Add(int a,int b)
        {
            return a + b;
        }
    }
}
