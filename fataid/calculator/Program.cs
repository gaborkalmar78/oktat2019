using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool GoOn = true;
            double lastresult = 0;
            Console.WriteLine("Kezdő érték = " + lastresult.ToString());
            do
            {
                EnumOperand operand = AskForOperand();
                switch (operand)
                {
                    case EnumOperand.Quit:
                        GoOn = false;
                        break;
                    default:
                        lastresult = CalculateValue(operand, lastresult);
                        Console.WriteLine("Az eredmény = " + lastresult.ToString());
                        break;
                }
            } while (GoOn);

        }

        static EnumOperand AskForOperand()
        {
            EnumOperand operand = EnumOperand.Quit;
            bool cont = false;
            do
            {
                Console.WriteLine("Adj meg egy műveletet! (=, +, -, *, /, %, !, x vagy q a kilépéshez)");
                string userinput = Console.ReadLine();
                cont = false;
                switch (userinput)
                {
                    case "+":
                        operand = EnumOperand.Add;
                        break;
                    case "-":
                        operand = EnumOperand.Substract;
                        break;
                    case "*":
                        operand = EnumOperand.Multiply;
                        break;
                    case "/":
                        operand = EnumOperand.Division;
                        break;
                    case "%":
                        operand = EnumOperand.Modulo;
                        break;
                    case "!":
                        operand = EnumOperand.Factorial;
                        break;
                    case "=":
                        operand = EnumOperand.Define;
                        break;
                    case "x":
                        operand = EnumOperand.Power;
                        break;
                    case "q":
                        operand = EnumOperand.Quit;
                        break;
                    default:
                        cont = true;
                        break;
                }
            } while (cont);
            return operand;
        }
        static double CalculateValue(EnumOperand operand, double argument)
        {
            bool wrongnumber = true;
            double result = 0;
            do
            {
                wrongnumber = false;
                Console.Write("Adj meg egy számot!");
                Console.WriteLine("");
                string userinput = Console.ReadLine();
                try
                {
                    double number = double.Parse(userinput);
                    switch (operand)
                    {
                        case EnumOperand.Add:
                            result = argument + number;
                            break;
                        case EnumOperand.Substract:
                            result = argument - number;
                            break;
                        case EnumOperand.Multiply:
                            result = argument * number;
                            break;
                        case EnumOperand.Division:
                            if (number == 0)
                            {
                                wrongnumber = true;
                                Console.WriteLine("Nullával nem lehet osztani!");
                                continue;
                            }
                            result = argument / number;
                            break;
                        case EnumOperand.Modulo:
                            result = argument % number;
                            break;
                        case EnumOperand.Define:
                            result = number;
                            break;
                        case EnumOperand.Factorial:
                            if ((number % 1) != 0)
                            {
                                Console.WriteLine("Tört számmal nem számolok faktoriálist!");
                                break;
                            }
                            int i;
                            result = 1;
                            for (i = 2; i <= number; i++)
                            {
                                result *= i;
                            }
                            break;
                        case EnumOperand.Power:
                            if ((number % 1) != 0 || number <= 1)
                            {
                                Console.WriteLine("Egyellőre csak pozitív, egész számmal tudok hatványozni!");
                                break;
                            }
                            int j;
                            result = argument;
                            for (j = 1; j < number; j++)
                            {
                                result *= argument;
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    wrongnumber = true;
                }
            } while (wrongnumber);
            return result;
        }
    }
}
