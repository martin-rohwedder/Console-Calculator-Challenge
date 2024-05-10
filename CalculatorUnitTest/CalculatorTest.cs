using CalculatorLib;
using System.Data;

namespace CalculatorUnitTest
{
    [TestFixture]
    internal class CalculatorTest
    {
        [TestCase("2+3*4", ExpectedResult = 14)]
        [TestCase("3*4+2", ExpectedResult = 14)]
        [TestCase("3*(4+2)", ExpectedResult = 18)]
        [TestCase("3*(4+2)/2", ExpectedResult = 9)]
        [TestCase("3.5+4.5", ExpectedResult = 8)]
        [TestCase("3.5+5", ExpectedResult = 8.5)]
        [TestCase("-2+1", ExpectedResult = -1)]
        [TestCase("-2+3", ExpectedResult = 1)]
        [TestCase("2 + 2", ExpectedResult = 4)]
        public decimal Calculate_Should_ReturnResultAsADecimal_WhenGivenStringMathExpressionIsInCorrectFormat(string expression)
        {
            // Arrange
            ICalculator calculator = new Calculator();

            // Act & Assert
            return calculator.Calculate(expression);
        }

        [Test]
        public void Calculate_Should_ThrowFormatException_WhenGivenStringMathExpressionIsTryingToDivideByZero()
        {
            // Arrange
            ICalculator calculator = new Calculator();

            // Act & Assert
            Assert.That(() => calculator.Calculate("3*(4+2)/0"), Throws.TypeOf<FormatException>());
        }

        [Test]
        public void Calculate_Should_ThrowEvaluateException_WhenGivenStringMathExpressionInABadFormat()
        {
            // Arrange
            ICalculator calculator = new Calculator();

            // Act & Assert
            Assert.That(() => calculator.Calculate("Hello"), Throws.TypeOf<EvaluateException>());
        }

        [Test]
        public void Calculate_Should_ThrowSyntaxErrorException_WhenGivenStringMathExpressionContainsNonMathOperators()
        {
            // Arrange
            ICalculator calculator = new Calculator();

            // Act & Assert
            Assert.That(() => calculator.Calculate("2+2 Thousand"), Throws.TypeOf<SyntaxErrorException>());
        }
    }
}
