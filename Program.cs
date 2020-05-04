using System;
using System.Threading.Tasks;
using System.Threading;

namespace task
{
     class Program
    {
        static object locker = new Object(); 
        static int GlobalLength = 30;
        static int flag = 0;
        static void Main(string[] args)
        {
            Parallel.ForEach(new int[]{1,3,5,7,9,11,13,15,17,19}, DoubleStream);
            //DoubleStreamAsync();
            //Thread[] newThrd = new Thread[10];
            //for (int i = 0; i < 10; i++){
            //    newThrd[i] = new Thread (new ParameterizedThreadStart (DoubleStream));
            //    newThrd[i].Start(i+2);
            //}
            System.Console.WriteLine("Hello");
            Thread.Sleep(800000);
            Console.ReadKey();            
        }
        static void Stream(int left){
            int limit = new Random().Next(3,5);
            int fixLim = limit; 
            int top = 0;
            int makeEmpty = top;
            int deleteFrom = GlobalLength;
            while(true){
                lock(locker){
                    if(top + limit >= GlobalLength){
                        limit = GlobalLength - top;
                        if(limit < 0){
                            limit = fixLim;
                            top = 0;
                        }    
                    }                
                    makeEmpty = top;
                    for (int i = deleteFrom; i < makeEmpty; i++){
                        Console.CursorTop = i;
                        Console.CursorLeft = left;
                        System.Console.WriteLine(" ");
                    }
                    if(top == 0){
                        for (int i = deleteFrom; i < GlobalLength; i++){
                            Console.CursorTop = i;
                            Console.CursorLeft = left;
                            System.Console.WriteLine(" ");
                        }
                    }
                    for(int i = 0; i < limit; i++){
                        if(i == (limit - 1))
                            Console.ForegroundColor = ConsoleColor.White;
                        else if(i == (limit - 2))
                            Console.ForegroundColor = ConsoleColor.Green;
                        else 
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.CursorTop = top++;
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
                    deleteFrom = top - limit;
                    top = makeEmpty + new Random().Next(2,4);
                }
                if(deleteFrom >= 8 && flag == 0){
                    Task newTask = new Task(() => Stream(left));
                    newTask.Start();
                    flag = 1;
                }
                Thread.Sleep(500);
            }
        }
        static void DoubleStream(int left){
            flag = 0;
            Stream(left);
        }
        //static async void DoubleStreamAsync(){
        //    System.Console.WriteLine("Start working");
        //    await Task.Run(() => Stream (5));
        //    System.Console.WriteLine("End work");
        //}
    }
} 