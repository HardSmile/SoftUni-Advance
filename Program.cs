﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Stack<int> numbers = new Stack<int>();
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string[] cmnd = Console.ReadLine().Split().ToArray();

                    string cmndType = cmnd[0];
                    if (cmndType == "1")
                    {
                        int element = int.Parse(cmnd[1]);
                        numbers.Push(element);
                    }
                    else if (cmndType == "2")
                    {
                        if (numbers.Any())
                        {
                            numbers.Pop();
                        }
                    }
                    else if (cmndType == "3")
                    {
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Max());
                        }
                    }
                    else if (cmndType == "4")
                    {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
                }
                Console.WriteLine(string.Join(", ", numbers));
            }
        }
    }