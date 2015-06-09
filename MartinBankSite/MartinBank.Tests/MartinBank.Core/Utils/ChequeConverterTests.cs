using MartinBank.Core.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MartinBank.Tests.MartinBank.Core.Utils
{
    [TestClass]
    public class ChequeConverterTests
    {
        [TestInitialize]
        public void Start() {}

        [TestMethod]
        public void ChequeConverter_Returns_TextZeroValue()
        {
            // arrange
            double input = 0d;
            // act
            string expectedText = ChequeConverter.NumericAmountToWords(input);
            // assert
            Assert.AreEqual("Zero dollars and zero cents", expectedText);
        }

        [TestMethod]
        public void ChequeConverter_Returns_TextWithOneDigitAndTwoDecimals()
        {
            // arrange
            double input = 1.20;
            // act
            string expectedText = ChequeConverter.NumericAmountToWords(input);
            // assert
            Assert.AreEqual("One dollars and Two cents", expectedText);
        }

        [TestMethod]
        public void ChequeConverter_Returns_TextWithThreeDigitsAndTwoDecimals()
        {
            // arrange
            double input = 125.42;
            // act
            string expectedText = ChequeConverter.NumericAmountToWords(input);
            // assert
            Assert.AreEqual("One Hundred and Twenty Five dollars and Fourty Two cents", expectedText);
        }

        [TestMethod]
        public void ChequeConverter_Returns_TextWithFourDigitsAndTwoDecimals()
        {
            // arrange
            double input = 3456.77;
            // act
            string expectedText = ChequeConverter.NumericAmountToWords(input);
            // assert
            Assert.AreEqual("Three Thousand and Four Hundred and Fifty Six dollars and Seventy Seven cents", expectedText);
        }

        [TestMethod]
        public void ChequeConverter_Returns_TextWithNineDigitsAndTwoDecimals()
        {
            // arrange
            double input = 121245452.11;
            // act
            string expectedText = ChequeConverter.NumericAmountToWords(input);
            // assert
            Assert.AreEqual("One Hundred and Twenty One Million and Two Hundred and Fourty Five Thousand and Four Hundred and Fifty Two dollars and Eleven cents", expectedText);
        }

        [TestCleanup]
        public void End() {}

    }
}
