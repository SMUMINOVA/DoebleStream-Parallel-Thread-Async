﻿using System;
using System.Threading.Tasks;

namespace task
{
    class Program
    {
        static object locker = new Object(); 
        static int GlobalLength = 10;
        static void Main(string[] args)
        {
            Parallel.ForEach(new int[]{1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39}, Stream);
            Console.ReadKey();            
        }
        static void Stream(int left){
            int limit1 = new Random().Next(3,7);
            int fixLim = limit1; 
            int top1 = 0;
            int empty = top1;
            while(true){
                lock(locker){
                    if(top1 + limit1 >= GlobalLength){
                        limit1 = GlobalLength - top1;
                        if(limit1 < 0)
                           limit1 = 0;
                    }                    
                    if(limit1 == 0){
                        limit1 = fixLim;
                        top1 = 0;
                    }                    
                    empty = top1;
                    for (int i = 0; i < empty; i++){
                        Console.CursorTop = i;
                        Console.CursorLeft = left;
                        System.Console.WriteLine(" ");
                    }
                    for(int i = 0; i < limit1; i++){
                        if(i == (limit1 - 1))
                            Console.ForegroundColor = ConsoleColor.White;
                        else if(i == (limit1 - 2))
                            Console.ForegroundColor = ConsoleColor.Green;
                        else 
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.CursorTop = top1++;
                        Console.CursorLeft = left;
                        switch(new Random().Next(0,15)){
                                case 0: System.Console.WriteLine("A");break;
                                case 1: System.Console.WriteLine("B");break;
                                case 2: System.Console.WriteLine("C");break;
                                case 3: System.Console.WriteLine("D");break;
                                case 4: System.Console.WriteLine("E");break;
                                case 5: System.Console.WriteLine("F");break;
                                case 6: System.Console.WriteLine("0");break;
                                case 7: System.Console.WriteLine("1");break;
                                case 8: System.Console.WriteLine("2");break;
                                case 9: System.Console.WriteLine("3");break;
                                case 10: System.Console.WriteLine("4");break;
                                case 11: System.Console.WriteLine("5");break;
                                case 12: System.Console.WriteLine("6");break;
                                case 13: System.Console.WriteLine("7");break;
                                case 14: System.Console.WriteLine("8");break;
                                case 15: System.Console.WriteLine("9");break;
                            }
                    }
                    if(top1 == limit1){
                        for (int i = top1; i < GlobalLength; i++){
                            Console.CursorTop = i;
                            Console.CursorLeft = left;
                            System.Console.WriteLine(" ");
                        }
                    }                    
                    top1 = empty + new Random().Next(1,5);
                }
            }
        }
    }
} 