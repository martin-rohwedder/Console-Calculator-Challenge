using CalculatorLib;
using System.Data;

namespace CalculatorChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            Console.WriteLine("Welcome to the calculator");
            Console.WriteLine("");
            Console.WriteLine("HOW TO USE:");
            Console.WriteLine("");
            Console.WriteLine("Type in a mathematical expression to use the calculator.");
            Console.WriteLine("Type 'exit' when you're done using the calculator.");
            Console.WriteLine("");
            Console.WriteLine("Do some math ...");

            string input = "";

            do
            {
                try
                {
                    input = Console.ReadLine();

                    if (!input.Trim().ToLower().Equals("exit"))
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"{input} = {calculator.Calculate(input)}");
                    }
                }
                catch (SyntaxErrorException)
                {
                    WriteFormatErrors();
                }
                catch (FormatException)
                {
                    WriteFormatErrors();
                }
                catch (EvaluateException)
                {
                    WriteFormatErrors();
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong!");
                    Console.WriteLine("Please try again!");
                    Console.WriteLine("");
                }
                finally
                {
                    Console.WriteLine("");
                    Console.WriteLine("Do some math ...");
                }
            }
            while (!input.Trim().ToLower().Equals("exit"));
        }

        private static void WriteFormatErrors()
        {
            Console.WriteLine("The calculator only accepts mathematical expression as +, -, *, / and parentheses ( )");
            Console.WriteLine("Please try again!");
            Console.WriteLine("");
        }
    }
}
