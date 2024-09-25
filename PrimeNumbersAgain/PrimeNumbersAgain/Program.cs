using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PrimeNumbersAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds} seconds and {timer.Elapsed.Milliseconds} milliseconds.");

            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

        static int FindNthPrime(int n)
        {
            //returns 2 if n is one, this simplifies some cases for calculation
            if (n == 1) return 2;

            bool[] startList = new bool[32452846];

            //sets the list to true
            for(int i = 0; i < startList.Length; i++)
            {
                startList[i] = true;
            }

            //calls and returns filteredNumbers
            return FilterNumbers(startList, n);
        }

        static int FilterNumbers(bool[] numbers, int target)
        {
            List<int> result = new List<int>();

            //sets all elements that are multiples of prime numbers to false, then adds all true elements to an int list
            for (int i = 2; i < numbers.Length; i++)
            {

                if (numbers[i])
                {
                    result.Add(i);
                    if (result.Count > target)
                        return result[target - 1];
                    for (int j = i + i; j < numbers.Length; j += i)
                        numbers[j] = false;
                }

            }

            return result[target-1];
        }

        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 3 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}
