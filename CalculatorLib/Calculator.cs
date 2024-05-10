using System.Data;

namespace CalculatorLib
{
    public class Calculator : ICalculator
    {
        public decimal Calculate(string expression)
        {
            DataTable dt = new DataTable();
            var result = dt.Compute(expression, string.Empty);

            return Convert.ToDecimal(result.ToString());
        }
    }
}
