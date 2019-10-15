using System;
using System.IO;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetEnumOperand());




        }


        static bool igaze()
        {



            Console.WriteLine("irj be egy muveletet");
            string jel = Console.ReadLine();
            bool viszaters = true;
            foreach (car a in jel)
            {

                if (a == '1' || a == '2' || a == '3' || a == '4' || a == '5' || a == '6' || a == '7' || a == '8' || a == '9' || a == '0')
                {

                }
                else
                {
                    viszaters = false;

                }
            }
            return viszaters;

        }

        static string muvelet()
        {

        }







    }
}




