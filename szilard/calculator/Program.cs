using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetEnumOperand());




        }

        static enumOperand GetEnumOperand()
        {
            enumOperand resault = enumOperand.quit;
            bool ok = false;
            do
            {
                Console.Write("mit csináljakl?");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "+":
                        resault = enumOperand.add;
                        ok = true;
                        break;
                    case "-":
                        resault = enumOperand.Substract;
                        ok = true;
                        break;
                    case "*":
                        resault = enumOperand.Multiple;
                        ok = true;
                        break;
                    case "/":
                        resault = enumOperand.Division;
                        ok = true;
                        break;
                    case "q":
                        break;
                    default:
                        break;
                }
                return resault;
            } while (ok);


        }
    }
}



