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
                Console.WriteLine("choose ur option! (+, -, *, % , / or q a kilépéshez)");
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
                        operand = EnumOperand.Multiple;
                        break;
                    case "/":
                        operand = EnumOperand.Division;
                        break;
                    case "q":
                        operand = EnumOperand.Quit;
                        break;
                    case "%":
                        operand = EnumOperand.Maradek;
                        break;
                    case "cos":
                        operand = EnumOperand.COS;
                        break;
                    case "cosh":
                        operand = EnumOperand.COSH;
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
                Console.Write("write a number!");
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
                        case EnumOperand.Multiple:
                            result = argument * number;
                            break;
                        case EnumOperand.Maradek:
                            result = argument % number;
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
                        case EnumOperand.COS:
                            result = Math.Cos(argument);
                            break;
                        case EnumOperand.COS:
                            result = Math.Cosh(number);
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







