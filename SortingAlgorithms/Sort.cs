using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace SortingAlgorithms
{
    abstract class Sort
    {
        internal abstract void Sorting(int[] numbers);
        internal abstract void SortName();
        internal Stopwatch stopWatch = new Stopwatch();

        static internal void Print(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }

    }

    class Insertion : Sort
    {
        internal override void SortName()
        {
            Console.WriteLine(" Insertion Sort: ");
        }
        internal override void Sorting(int[] numbers)
        {
           stopWatch.Start();
        
            for (int i = 1; i < numbers.Length; ++i)
            {
                int key = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = key;
            }

            stopWatch.Stop();

            Sort.Print(numbers);
            Console.WriteLine();
            Console.WriteLine($"Time elapsed: { stopWatch.Elapsed}"); 
        }

       
    }
    class Bubble : Sort
    {
        internal override void SortName()
        {
            Console.WriteLine(" Bubble Sort: ");
        }
        internal override void Sorting(int[] numbers)
        {
            stopWatch.Start();
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
            stopWatch.Stop();

            Sort.Print(numbers);
            Console.WriteLine();
            Console.WriteLine($"Time elapsed: { stopWatch.Elapsed}");
        }
    }
    class Shell : Sort
    {
        internal override void SortName()
        {
            Console.WriteLine(" Shell Sort: ");
        }
        internal override void Sorting(int[] numbers)
        {
            stopWatch.Start();
            int n = numbers.Length;
           
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = numbers[i];
                    int j;
                    for (j = i; j >= gap && numbers[j - gap] > temp; j -= gap)
                        numbers[j] = numbers[j - gap];
                    numbers[j] = temp;
                }
            }
            stopWatch.Stop();

            Sort.Print(numbers);
            Console.WriteLine();
            Console.WriteLine($"Time elapsed: { stopWatch.Elapsed}");
        }
    }


    class Quick : Sort
    {
        internal override void SortName()
        {
            Console.WriteLine(" Quick Sort: ");
        }
        internal override void Sorting(int[] numbers)
        {
            stopWatch.Start();
            SortQuick(numbers, 0, numbers.Length - 1);
            stopWatch.Stop();

            Sort.Print(numbers);
            Console.WriteLine();
            Console.WriteLine($"Time elapsed: { stopWatch.Elapsed}");
        }

        void SortQuick(int[] numbers, int left, int right)
        {
           
            if (left < right)
            {
                int pivot = Partition(numbers, left, right);

                if (pivot > 1)
                    SortQuick(numbers, left, pivot - 1);

                if (pivot + 1 < right)
                    SortQuick(numbers, pivot + 1, right);
            }

        }
        static public int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];

            while (true)
            {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }

    class Merge : Sort
    {
        internal override void SortName()
        {
            Console.WriteLine(" Merge Sort: ");
        }
        internal override void Sorting(int[] numbers)
        {
            stopWatch.Start();
            sort(numbers, 0, numbers.Length - 1);
            stopWatch.Stop();

            Sort.Print(numbers);
            Console.WriteLine();
            Console.WriteLine($"Time elapsed: { stopWatch.Elapsed}");
        }

        void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                sort(arr, l, m);
                sort(arr, m + 1, r);
                merge(arr, l, m, r);
            }
        }
        void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
    }
    class Heap : Sort
    {
        internal override void SortName()
        {
            Console.WriteLine(" Heap Sort: ");
        }
        internal override void Sorting(int[] numbers)
        {
            stopWatch.Start();

            int n = numbers.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(numbers, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                int temp = numbers[0];
                numbers[0] = numbers[i];
                numbers[i] = temp;

                heapify(numbers, i, 0);
            }
            stopWatch.Stop();

            Sort.Print(numbers);
            Console.WriteLine();
            Console.WriteLine($"Time elapsed: { stopWatch.Elapsed}");
        }
        void heapify(int[] arr, int n, int i)
        {
            int largest = i; 
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && arr[l] > arr[largest])
                largest = l;

            if (r < n && arr[r] > arr[largest])
                largest = r;

            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                heapify(arr, n, largest);
            }
        }

    }
}
