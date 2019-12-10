using System;
using System.Collections.Generic;

namespace _010
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] RandNums = MakeIntArray(5);
            PrintArray(" before sorting", RandNums);
            //int[] SortNums = SortArray1(RandNums);
            //SortArray2(RandNums);
            SortArrayBubble(RandNums);
            //PrintArray(SortNums);
            PrintArray(" after sorting", RandNums);
            // PrintArray(RandNums);

            // int[] Numbers = new int[] {
            //     34, 40, 10, 1, 95
            // };
            // Console.WriteLine("Hello World!");
        }
        static private int[] MakeIntArray(int size)
        {
            int[] RandNums = new int[size];
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < RandNums.Length; i++)
            {
                RandNums[i] = rand.Next(1000);

            }
            return RandNums;
        }
        static private void PrintArray(string suffix, int[] intArray)
        {
            // Console.WriteLine("");
            Console.WriteLine("\nArray's elements" + suffix + ": ");
            for (int i = 0; i < intArray.Length; i++)
            {
                //Console.WriteLine("Array's " + (i + 1).ToString() + ". element is: " + intArray[i].ToString());
                // Console.Write(intArray[i].ToString() + "; ");
                Console.Write($"{intArray[i],3}, ");
                if (i % 10 == 9)
                {
                    Console.Write("\n");
                }
            }
            if (intArray.Length % 10 != 0)
            {
                Console.Write("\n");
            }

        }
        static private int[] SortArray1(int[] intArray)
        {
            int[] SortedArray = new int[intArray.Length];
            if (SortedArray.Length == 0)
            {
                return SortedArray;
            }
            int iMax = intArray[0];
            for (int j = 1; j < intArray.Length; j++)
            {
                if (iMax < intArray[j])
                {
                    iMax = intArray[j];
                }
            }
            //Console.WriteLine("\nArray's biggest number: " + iMax.ToString());
            iMax++;
            //iMax = int.MaxValue;
            int iMin = intArray[0];
            for (int k = 0; k < intArray.Length; k++)
            {
                int iPos = 0;
                for (int i = 0; i < intArray.Length; i++)
                {
                    if (iMin > intArray[i] && intArray[i] < iMax)
                    {
                        iPos = i;
                        iMin = intArray[i];

                    }
                }
                SortedArray[k] = iMin;
                intArray[iPos] = iMax;
                iMin = iMax;
            }
            return SortedArray;
        }
        static private void SortArray2(int[] intArray)
        {
            int iMin;
            int iPos = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                iMin = intArray[i];
                iPos = i;
                for (int k = (i + 1); k < intArray.Length; k++)
                {
                    if (iMin > intArray[k])
                    {
                        iPos = k;
                        iMin = intArray[k];
                    }
                }
                intArray[iPos] = intArray[i];
                intArray[i] = iMin;
                //PrintArray("Currently ", intArray);
            }
            return;
        }
        static private void SortArrayBubble(int[] intArray)
        {
            for (int i = 1; i < intArray.Length; i++)
            {
                for (int k = 1; k <= (intArray.Length - i); k++)
                {
                    if (intArray[k] < intArray[k - 1])
                    {
                        int iTemp = intArray[k];
                        intArray[k] = intArray[k - 1];
                        intArray[k - 1] = iTemp;
                        //PrintArray(" currently", intArray);

                    }
                }
            }
            return;
        }
    }
}
