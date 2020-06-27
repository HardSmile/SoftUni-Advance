using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] males = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] females = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stackMales = new Stack<int>(males);
            Queue<int> queueFemales = new Queue<int>(females);
            int specialCase = 25;
            int matchesCount = 0;
            

            while (stackMales.Count > 0 && queueFemales.Count > 0)
            {
                int male = stackMales.Peek();
                int female = queueFemales.Peek();
                if(male <= 0)
                {
                    stackMales.Pop();
                    continue;
                }
                else if (female <= 0)
                {
                    queueFemales.Dequeue();
                    continue;
                }
                if (male % specialCase == 0)
                {
                    if(stackMales.Count == 1)
                    {
                        stackMales.Pop();
                        break;
                    }
                    else
                    {
                        stackMales.Pop();
                        stackMales.Pop();
                        continue;
                    }

                }
                if(female % specialCase == 0)
                {
                    if(queueFemales.Count == 1)
                    {
                        queueFemales.Dequeue();
                        break;
                    }
                    else
                    {
                        queueFemales.Dequeue();
                        queueFemales.Dequeue();
                        continue;
                    }
                }
                if (male == female)
                {
                    stackMales.Pop();
                    queueFemales.Dequeue();
                    matchesCount++;
                }
                else
                {
                    queueFemales.Dequeue();
                    stackMales.Pop();
                    stackMales.Push(male - 2);
                }
            }
            List<string> result = new List<string>();
                Console.WriteLine($"Matches: {matchesCount}");
            if(stackMales.Count > 0)
            {
                foreach (var item in stackMales)
                {
                    result.Add(item.ToString());
                }
                Console.Write($"Males left: {String.Join(", ", result)}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Males left: none");
            }
         
            if (queueFemales.Count > 0)
            {
                foreach (var item in queueFemales)
                {
                    result.Add(item.ToString());
                }
                Console.Write($"Females left: {String.Join(", ",result)}");

            }
            else
            {
                Console.WriteLine("Females left: none");
            }


        }
    }
}
