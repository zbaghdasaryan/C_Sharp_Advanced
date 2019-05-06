using System;

namespace Sorting_Algorithms
{
    class Program
    {
        static Random rand = new Random();

        public static int[] GetRandomArray(int length, int MinValue, int MaxValue)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(MinValue, MaxValue);
            }
            return array;
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void BubbleSort(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] > array[j + 1])
                        Swap(ref array[j], ref array[j + 1]);
                }
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (array[j] > array[j + 1])
                        Swap(ref array[j], ref array[j + 1]);
                    else
                        break;
                }
            }
        }


        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = array[i];
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        minIndex = j;
                        Swap(ref array[i], ref array[minIndex]);
                    }                                       
                }
            }
        }


        static void Main(string[] args)
        {
            int[] a = GetRandomArray(10, -10, 50);
            Console.WriteLine("not sorted array");
            foreach (var item in a)
            {
                Console.Write(" " + item);
            }
            //BubbleSort(a);
            //InsertionSort(a);
            SelectionSort(a);
            Console.WriteLine("\n\nsorted array");
            foreach (var item in a)
            {
                Console.Write(" " + item);
            }
            Console.ReadKey();
        }
    }
}


/*

         static void Main(string[] args)
        {

            int[] a = GetRandomArray(20, -100, 100);
            //BubbleSort(a);
            //SelectionSort(a);
            //InsertionSort(a);
            IntArrayQuickSort(a);


            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }

        

        public static void SelectionSort(int[] array)
        {
            int N = array.Length;

            for (int i = 0; i < N - 1; i++)
            {
                int min = array[i];
                int minind = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        minind = j;
                    }
                }
                //if(i != minind)
                swap1(ref array[i], ref array[minind]);
            }
        }

        
        }

        public static void IntArrayQuickSort(int[] data, int l, int r)
        {
            int i, j;
            int x;

            i = l;
            j = r;

            x = data[(l + r) / 2]; /* find pivot item 
            while (true)
            {
                while (data[i] < x)
                    i++;
                while (x < data[j])
                    j--;
                if (i <= j)
                {
                    swap(ref data[i], ref data[j]);
                    i++; j--;
                }
                if (i > j)
                    break;
            }
            if (l < j)
                IntArrayQuickSort(data, l, j);
            if (i < r)
                IntArrayQuickSort(data, i, r);
        }

        public static void IntArrayQuickSort(int[] data)
        {
            IntArrayQuickSort(data, 0, data.Length - 1);
        }

        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }





    }
}
*/
