using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter the size of an array that you want to sort: ");

                bool isParse = false;

                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    isParse = true;
                }

                if (isParse)
                {
                    Console.WriteLine();
                    Console.WriteLine("Select which algorithm you want to perform:");
                    Console.WriteLine("1.Bubble sort, \n2.Insertion sort, \n3.Shell sort, \n4.Heap sort, \n5.Marge sort, \n6.Quick sort, \n7.All:");
                    while (true)
                    {

                        Console.WriteLine("Selection: ");

                        string algoritmCount = Console.ReadLine();
                        Console.WriteLine();

                        int[] numbers = new int[n];
                        RandomDigits(numbers);

                        List<Sort> sortList = new List<Sort>();

                        string[] symbols = algoritmCount.Split(" 1234567".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        List<int> num = new List<int>();
                        string[] numberAlgoritms = algoritmCount.Split(" -,".ToCharArray());

                        bool isDigit = true;
                        if (!numberAlgoritms.Contains("1") && !numberAlgoritms.Contains("2") && !numberAlgoritms.Contains("3") && !numberAlgoritms.Contains("4")
                            && !numberAlgoritms.Contains("5") && !numberAlgoritms.Contains("6") && !numberAlgoritms.Contains("7"))
                        {
                            isDigit = false;
                        }

                        if (isDigit)
                        {
                            foreach (string number in numberAlgoritms)
                            {
                                num.Add(int.Parse(number));
                            }
                        }
                        else
                        {

                            Console.WriteLine("This does not match the format, please enter numbers.");
                            Console.WriteLine();
                            continue;
                        }


                        long size1Memory = default;
                        long size2Memory = default;


                        if (symbols.Contains("-"))
                        {
                            for (int i = num[0]; i <= num[num.Count - 1]; i++)
                            {
                                ListObjects(i, sortList);
                                sortList[i - num[0]].SortName();

                                size1Memory = GC.GetTotalMemory(false);
                                sortList[i - num[0]].Sorting((int[])numbers.Clone());
                                size2Memory = GC.GetTotalMemory(false);

                                Console.WriteLine($"Memory size 1: { size1Memory}");
                                Console.WriteLine($"Memory size 2: { size2Memory}");
                                Console.WriteLine($"Memory size: { size2Memory - size1Memory}");
                                Console.WriteLine();
                            }
                        }
                        if (symbols.Contains(","))
                        {
                            for (int i = 0; i < num.Count; i++)
                            {
                                ListObjects(num[i], sortList);
                                sortList[i].SortName();

                                size1Memory = GC.GetTotalMemory(false);
                                sortList[i].Sorting((int[])numbers.Clone());
                                size2Memory = GC.GetTotalMemory(false);

                                Console.WriteLine($"Memory size 1: { size1Memory}");
                                Console.WriteLine($"Memory size 2: { size2Memory}");
                                Console.WriteLine($"Memory size: { size2Memory - size1Memory}");
                                Console.WriteLine();
                            }
                        }

                        switch (algoritmCount)
                        {
                            case "1":
                                ImplementationForNumberOne(sortList, numbers, algoritmCount, size1Memory, size2Memory);
                                break;
                            case "2":
                                ImplementationForNumberOne(sortList, numbers, algoritmCount, size1Memory, size2Memory);
                                break;
                            case "3":
                                ImplementationForNumberOne(sortList, numbers, algoritmCount, size1Memory, size2Memory);
                                break;
                            case "4":
                                ImplementationForNumberOne(sortList, numbers, algoritmCount, size1Memory, size2Memory);
                                break;
                            case "5":
                                ImplementationForNumberOne(sortList, numbers, algoritmCount, size1Memory, size2Memory);
                                break;
                            case "6":
                                ImplementationForNumberOne(sortList, numbers, algoritmCount, size1Memory, size2Memory);
                                break;
                            case "7":
                                for (int i = 1; i <= 6; i++)
                                {
                                    ImplementationForNumberAll(sortList, numbers, i.ToString(), size1Memory, size2Memory);
                                    Console.WriteLine();
                                }
                                break;
                        }

                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.WriteLine("This does not match the format, please enter numbers.");
                }
            }
        }

        private static void ImplementationForNumberOne(List<Sort> sortList, int[] numbers, string algoritmCount, long size1Memory, long size2Memory)
        {
            ListObjects(int.Parse(algoritmCount), sortList);
            sortList[0].SortName();

            size1Memory = GC.GetTotalMemory(false);
            sortList[0].Sorting((int[])numbers.Clone());
            size2Memory = GC.GetTotalMemory(false);

            Console.WriteLine($"Memory size 1: { size1Memory}");
            Console.WriteLine($"Memory size 2: { size2Memory}");
            Console.WriteLine($"Memory size: { size2Memory - size1Memory}");
            Console.WriteLine();
        }
        private static void ImplementationForNumberAll(List<Sort> sortList, int[] numbers, string algoritmCount, long size1Memory, long size2Memory)
        {
            ListObjects(int.Parse(algoritmCount), sortList);
            sortList[int.Parse(algoritmCount) - 1].SortName();

            size1Memory = GC.GetTotalMemory(false);
            sortList[int.Parse(algoritmCount) - 1].Sorting((int[])numbers.Clone());
            size2Memory = GC.GetTotalMemory(false);

            Console.WriteLine($"Memory size 1: { size1Memory}");
            Console.WriteLine($"Memory size 2: { size2Memory}");
            Console.WriteLine($"Memory size: { size2Memory - size1Memory}");
            Console.WriteLine();
        }


        static void ListObjects(int i, List<Sort> sortList)
        {
            switch (i)
            {
                case 1:
                    Sort sortBubble = new Bubble();
                    sortList.Add(sortBubble);
                    break;
                case 2:
                    Sort sortInsertion = new Insertion();
                    sortList.Add(sortInsertion);
                    break;
                case 3:
                    Sort sortShell = new Shell();
                    sortList.Add(sortShell);
                    break;
                case 4:
                    Sort sortHeap = new Heap();
                    sortList.Add(sortHeap);
                    break;
                case 5:
                    Sort sortMerge = new Merge();
                    sortList.Add(sortMerge);
                    break;
                case 6:
                    Sort sortQuick = new Quick();
                    sortList.Add(sortQuick);
                    break;
            }
        }
        static void RandomDigits(int[] numbers)
        {
            Random rand = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(1, 99);
            }

        }
    }
}
