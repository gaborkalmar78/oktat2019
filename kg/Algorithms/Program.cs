using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] numbers = new int[99];

            Fill(numbers);

            Print(numbers);
            Print(numbers);
        }

        static void Fill(int[] ints)
        {
            Random rnd = new Random();
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = rnd.Next(1000);
            }
        }

        static void Print(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write($"{ints[i],3}, ");
                if (i % 10 == 9)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
