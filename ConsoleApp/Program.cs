using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Schema;

namespace ConsoleApp1
{
    class Program
    {
        //sorting by frequency

        struct ElemIndex
        {
            public int Element;
            public int Index;
            public override bool Equals(object obj)
            {
                return obj is ElemIndex other && (Element == other.Element);
            }
            public override string ToString()
            {
                return "Element:"+ Element+" First Index: "+Index;
            }

        }
        static public void sortArrayByFrequency(int[] a)
        {
            var My_dic = new Dictionary<ElemIndex, int>();
           

            ElemIndex Ei = new ElemIndex();
            for(int i = 0; i < a.Length; i++)
            {
                Ei.Element = a[i];
                if (My_dic.ContainsKey(Ei))
                {
                    My_dic[Ei] = My_dic[Ei] + 1;
                }
                else
                {
                    My_dic.Add(new ElemIndex { Element = a[i], Index = i }, 1) ;
                }
            }
            var myList = My_dic.ToList();
            myList = myList.OrderByDescending(x => x.Value).ThenBy(x => x.Key.Index).ToList();
 
            int frequency = 0;
            foreach (KeyValuePair<ElemIndex, int> pair in myList)
            {
                frequency = pair.Value;
                for(int i=0;i< frequency; i++)
                {
                    Console.Write(pair.Key.Element+"  ");
                }
            }           
        }

        

        //Question 9
            static public void printSpiralArray(int[,] arr) {
            int x = arr.GetLength(1);// obtaing length of x
            int y = arr.GetLength(0); //length of y

            int j = 0, i = 0, layer = 1;
            while (layer <= x / 2 && layer<= y / 2)
            {
                while (i < (x - layer))//->
                {
                    Console.Write(arr[j, i] + " ");
                    i++;
                }
                while (j < (y - layer))
                {
                    Console.Write(arr[j, i] + " ");
                    j++;
                }
                while (i > (layer - 1))//<-
                {
                    Console.Write(arr[j, i] + " ");
                    i--;
                }
                while (j > (layer - 1))
                {
                    Console.Write(arr[j, i] + " ");
                    j--;
                }
                j = i = layer;
                layer++;
            }
            layer--;
             if(y%2==1 && x % 2 == 1)
               {
                Console.Write(arr[i, j]);
            }
             if(y%2==0 && x % 2 == 1)
            {
                while (j < y -layer)
                {
                    Console.Write(arr[j, i]+" ");
                    j++;
                }
            }
            if (x % 2 == 0 && y % 2 == 1)
            {
                while (i < x - layer)
                {
                    Console.Write(arr[j, i] + " ");
                    i++;
                }
            }
        }

       static public void printMatrix(int[,] a)
        {
            for(int i=0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[ i,j] + "\t");

                }
                Console.Write("\n");
            }
        }


        static void Main(string[] args)
        {
            int[] a = { 5, 2, 2, 8, 5, 6, 8, 8 };

            int[] b = { 2, 5, 2, 6, -1, 9999999, 5, 8, 8, 8 };
            sortArrayByFrequency(a);
            Console.WriteLine("\n");
            sortArrayByFrequency(b);
        }
    }
}
