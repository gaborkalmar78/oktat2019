using System;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {



            static void Main(string)
            enumOperand operand = enumOperand.add;
            Console.WriteLine("Hello World!");
        }


        static enumOperand GetOperand()
        {
            enumOperand result = enumOperand.quit;
            bool ok = false;

            do
            {

                Console.Write(" mit szeretnél? ");
                String Input = Console.ReadLine();




                switch (Input)
                {
                    case "+":
                        result = enumOperand.add;
                        ok = true;
                        break;
                    case "-":
                        result = enumOperand.Substrackt;
                        ok = true;
                        break;
                    case "/":
                        result = enumOperand.Multiple;
                        ok = true;
                        break;
                    case "*": result = enumOperand.Division; break;
                    case "q": result = enumOperand.quit; break;
                    default:
                        break;
                }

            } while (!ok);

            return result;
        }

        static int Getnumber()
        {
            int result = 0;
            bool ok = false;

            do
            {
                ok = true;

                Console.Write(" mit szeretnél? ");
                String Input = Console.ReadLine();



                try
                {
                    result = int.Parse(Input);

                }
                catch (Exception)
                {
                    ok = false;
                }



            } while (!ok);

            return result;

        }












    }
}







