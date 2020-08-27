using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Solutions
    {
        //Question 1
        static int maxSumSubarray(int[] a)
        {
            if (a.Length == 1)
            {
                return a[0];
            }
            int maxSum = a[0];
            int currentSum = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                currentSum += a[i];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
                if (currentSum < 0)
                {
                    currentSum = 0;
                }
            }
            return maxSum;
        }

        /// 
        static public int[] GetUniqueNumbers(int[] a, int w) //1<=w<=a.Lenght
        {
            int[] result = new int[a.Length + 1 - w];
            int x = 0, y = w - 1, resultIndex = 0;
            int counter = 0;
            List<int> uniques = new List<int>();

            while (y <= a.Length - 1)
            {
                for (int i = x; i <= y; i++)
                {
                    if (!uniques.Contains(a[i]))
                    {
                        uniques.Add(a[i]);
                        counter++;
                    }
                    else
                    {
                        counter--;
                    }
                }
                result[resultIndex] = counter;
                uniques.Clear();
                x++;
                y++;
                resultIndex++;
                counter = 0;
            }
            return result;
        }

        static public int[] sortArray(int[] a)
        {
            Dictionary<int, int> My_dic = new Dictionary<int, int>();
            My_dic.Add(0, 0);
            My_dic.Add(1, 0);
            My_dic.Add(2, 0);
            for (int i = 0; i < a.Length; i++)
            {
                My_dic[a[i]] = My_dic[a[i]] + 1;
            }

            if (My_dic[0] > 0)
            {
                for (int i = 0; i < My_dic[0]; i++)
                {
                    a[i] = 0;
                }
            }

            if (My_dic[1] > 0)
            {
                for (int i = My_dic[0]; i < (My_dic[0] + My_dic[1]); i++)
                {
                    a[i] = 1;
                }
            }

            if (My_dic[2] > 0)
            {
                for (int i = (My_dic[0] + My_dic[1]); i < (My_dic[0] + My_dic[1] + My_dic[2]); i++)
                {
                    a[i] = 2;
                }
            }
            return a;
        }

        static public int[] sortArray2(int[] a)
        {
            int j = 0, k = a.Length - 1, i = 0;
            int temp = 0, countOnes = 0;

            while (i < k)
            {
                if (a[i] == 2)
                {
                    if (a[k] == 2)
                    {
                        while (a[k] == 2 && k >= 0)
                        {
                            k--;
                        }
                    }
                    if (k > i)
                    {
                        temp = a[k];
                        a[k] = 2;
                        a[i] = temp;
                        k--;
                    }
                }
                if (a[i] == 1)
                {
                    if (j != i)
                        j++;
                    countOnes++;
                }
                if (a[i] == 0)
                {
                    if (countOnes > 0)
                    {
                        temp = a[j];
                        a[i - countOnes] = 0;
                        a[i] = temp;

                    }
                }
                i++;
            }
            return a;
        }
        static public int findTheMissingNumber(List<int> a)
        {
            int totalSum = a.Sum();
            return Math.Abs(totalSum - (((a.Count + 1) * (a.Count + 2)) / 2)); //n(n+1)/2
        }

        static public int findEquilibriumIndex(int[] a)
        {
            if (a.Length < 3)
                return -1;

            int sumLeft = a[0], sumRight = 0;
            int index = 1;

            for (int j = 2; j < a.Length; j++)
            {
                sumRight += a[j];
            }

            while (index <= a.Length - 2)
            {
                if (sumLeft == sumRight)
                    break;
                sumLeft += a[index];
                sumRight -= a[index + 1];
                index++;
            }
            if (index == a.Length - 1)
                return -1;
            return index;
        }
        //Question 8
        public static int[] mergeSort(int[] array)
        {
            int[] a;
            int[] b;
            int[] result = new int[array.Length];
            if (array.Length == 1) // base case
                return array;
            int midPoint = array.Length / 2;
            a = new int[midPoint];
            if (array.Length % 2 == 0)
                b = new int[midPoint];
            else
                b = new int[midPoint + 1];
            for (int i = 0; i < midPoint; i++)
                a[i] = array[i];
            int x = 0;
            for (int i = midPoint; i < array.Length; i++)
            {
                b[x] = array[i];
                x++;
            }
            //recursion
            a = mergeSort(a);
            b = mergeSort(b);
            result = merge(a, b);
            return result;
        }
        static private int[] merge(int[] a, int[] b)
        {
            int[] result = new int[a.Length + b.Length];
            int ia = 0, ib = 0, ir = 0;
            while (ia < a.Length || ib < b.Length)
            {
                if (ia < a.Length && ib < b.Length) //both arrays have elements
                {
                    if (a[ia] <= b[ib])
                    {
                        result[ir] = a[ia];
                        ia++;
                        ir++;
                    }
                    else
                    {
                        result[ir] = b[ib];
                        ib++;
                        ir++;
                    }
                }
                else if (ia < a.Length)//only a has elements
                {
                    result[ir] = a[ia];
                    ia++;
                    ir++;
                }
                else if (ib < b.Length)// only b has elements
                {
                    result[ir] = b[ib];
                    ib++;
                    ir++;
                }
            }
            return result;
        }

        static public int findKthSmaller(int[] a, int k)
        {
            // sort array
            int[] sorted = mergeSort(a);
            return sorted[k - 1];
        }

        //Question 7
        public static void findAllLeaders(int[] a)
        {
            int lastLeader = a[a.Length - 1];
            Console.Write("Leaders of the array: " + lastLeader);
            if (a.Length >= 2)
            {
                for (int i = a.Length - 2; i >= 0; i--)
                {
                    if (a[i] > lastLeader)
                    {
                        lastLeader = a[i];
                        Console.Write(" " + lastLeader);
                    }
                }
            }
        }

        //Question 3

        public static void findSubarray(int[] a, int k)
        {
            int currentSum;
            bool founded = false;
            for (int i = 0; i < a.Length; i++)
            {
                currentSum = 0;

                for (int j = i; j < a.Length; j++)
                {
                    currentSum += a[j];
                    if (currentSum == k)
                    {
                        Console.WriteLine("Sum found between indexes " + i + " and " + j);
                        founded = true;
                        return;
                    }
                    else
                    {
                        if (currentSum > k)
                        {
                            break;
                        }
                    }
                }
            }
            if (!founded)
                Console.WriteLine("No subarray found");
        }

        //Question 4
        public static void findSubarray2(int[] a, int k)
        {
            int currentSum;
            bool founded = false;
            for (int i = 0; i < a.Length; i++)
            {
                currentSum = 0;

                for (int j = i; j < a.Length; j++)
                {
                    currentSum += a[j];
                    if (currentSum == k)
                    {
                        Console.WriteLine("Sum found between indexes " + i + " and " + j);
                        founded = true;
                        return;
                    }
                   

                }
            }
            if (!founded)
                Console.WriteLine("No subarray with given sum exists");
        }


        //static void Main(string[] args)
        //{
        //    //List<int> myList1 = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15};

        //    //List<int> myList2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 };

        //    //Console.WriteLine("Missing number on List 1:" + findTheMissingNumber(myList1));
        //    //Console.WriteLine("Missing number on List 2:" + findTheMissingNumber(myList2));

        //    int[] a = { -7, 1, 5, 2, -4, 3 };
        //    int[] a2 = { 2, 4, 3, 1, 2, 0, 5, 2, 5 };
        //    int[] a3 = { 2, 4, -1, -1 };

        //    Console.WriteLine("[{0}]", string.Join(", ", a));
        //    Console.WriteLine(findEquilibriumIndex(a));
        //    Console.WriteLine("[{0}]", string.Join(", ", a2));
        //    Console.WriteLine(findEquilibriumIndex(a2));
        //    Console.WriteLine("[{0}]", string.Join(", ", a3));
        //    Console.WriteLine(findEquilibriumIndex(a3));

        //int[] a = { 16, 17, 4, 3, 5, 2 };
        //int[] a2 = { 2, 4, 3, 1, 6, 0, 5, 7, 8 };
        //int[] a3 = { 2, 4, 3, -1 };

        //Console.WriteLine("[{0}]", string.Join(", ", a));
        //    findAllLeaders(a);
        //Console.WriteLine(" \n");
        //    Console.WriteLine("[{0}]", string.Join(", ", a2));
        //    findAllLeaders(a2);
        //Console.WriteLine(" \n");
        //    Console.WriteLine("[{0}]", string.Join(", ", a3));
        //    findAllLeaders(a3);

        //Q4
        //int[] a = { 1, 4, 20, 3, 10, 5 };
        //int[] a2 = { 10, 2, -2, -20, 10 };
        //int[] a3 = { -10, 0, 2, -2, -20, 10 };


        //Console.WriteLine("[{0}]", string.Join(", ", a));
        //    Console.WriteLine("Sum=33 ");
        //    findSubarray(a, 33);
        //Console.WriteLine("\n");

        //    Console.WriteLine("[{0}]", string.Join(", ", a2));
        //    Console.WriteLine("Sum=-10 ");
        //    findSubarray(a2, -10);
        //Console.WriteLine("\n");

        //    Console.WriteLine("[{0}]", string.Join(", ", a3));
        //    Console.WriteLine("Sum=20 ");
        //    findSubarray(a3, 20);

        //Q9
        //int[,] a = { { 1, 2, 3, 4, 5, 6 },
        //               { 7, 8, 9, 10, 11, 12 },
        //               { 13, 14, 15, 16, 17, 18 } };
        //int[,] b = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
        //int[,] e = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };

        //printMatrix(a);
        //Console.WriteLine("\n");
        //    printSpiralArray(a);
        //Console.WriteLine("\n\n");
        //    printMatrix(b);
        //Console.WriteLine("\n");
        //    printSpiralArray(b);
        //Console.WriteLine("\n\n");
        //    printMatrix(e);
        //Console.WriteLine("\n");
        //    printSpiralArray(e);


    }
}
