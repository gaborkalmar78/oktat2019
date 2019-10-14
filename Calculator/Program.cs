using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            double value = 0;
            do
            {
                System.Console.WriteLine($"Current value: {value}");
                switch (GetOperator())
                {
                    case Operators.Add:
                        value += GetOperand();
                        break;
                    case Operators.Sub:
                        value -= GetOperand();
                        break;
                    case Operators.Mul:
                        value *= GetOperand();
                        break;
                    case Operators.Div:
                        value /= GetOperand();
                        break;
                    case Operators.Quit:
                        quit = true;
                        break;
                    default:
                        break;
                }

            } while (!quit);
        }

        private static Operators GetOperator()
        {
            Operators result = Operators.Nop;
            do
            {
                Console.Write("Művelet? ");
                string s = Console.ReadLine();
                switch (s)
                {
                    case "+":
                        result = Operators.Add;
                        break;
                    case "-":
                        result = Operators.Sub;
                        break;
                    case "*":
                        result = Operators.Mul;
                        break;
                    case "/":
                        result = Operators.Div;
                        break;
                    case "q":
                        result = Operators.Quit;
                        break;
                    default:
                        break;
                }
            } while (result == Operators.Nop);

            return result;
        }
        private static double GetOperand()
        {
            double result = 0;
            do
            {
                Console.Write("Érték? ");
            } while (!double.TryParse(Console.ReadLine(), out result));

            return result;
        }
    }
    public enum Operators
    {
        Nop = 0,
        Add = 1,
        Sub = 2,
        Mul = 3,
        Div = 4,
        Quit = 255
    }
}
