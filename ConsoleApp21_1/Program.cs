using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;

namespace ConsoleApp3_4
{
    public class Program
    {
        static char[,] garden = new char[9, 9];
       
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(gardener1));
            thread.Start(1);

            Thread thread1 = new Thread(new ParameterizedThreadStart(gardener1));
            thread1.Start(2); 
        }
        public static void Run()
        {
            bool done = false;
            while (!done)
            {
                Thread.Sleep(400);
            }
        }

        public static void gardener1(object num)
        {
            char[,] plan = new char[,] { {' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                         {' ','x', 'x', 'x', ' ', 'x', 'x', 'x', ' '},
                                         {' ','x', ' ', ' ', ' ', ' ', ' ', 'x', ' '},
                                         {' ','x', ' ', ' ', ' ', ' ', ' ', 'x', ' '},
                                         {' ',' ', 'x', 'x', ' ', 'x', 'x', ' ', ' '},
                                         {' ','x', ' ', ' ', ' ', ' ', ' ', 'x', ' '},
                                         {' ','x', ' ', ' ', ' ', ' ', ' ', 'x', ' '},
                                         {' ','x', 'x', 'x', ' ', 'x', 'x', 'x', ' '},
                                         {' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '} };

            int len = Convert.ToInt32(Math.Pow(plan.Length, 0.5));          
        
                if (Convert.ToInt32(num) == 1) //worker 1
                {
                    for (int i = len - 1; i >= 0; i--)
                    {
                        for (int j = len - 1; j >= 0; j--)
                        {
                            char curr_gar = garden[j, i];
                            if (curr_gar == 0)
                            {
                            if (plan[j, i] == 'x')
                                garden[j, i] = 'o';
                            else
                                garden[j, i] = '.';
                        }
                            for (int o = 1; o < 9; o++)
                            {
                                Console.WriteLine($"{garden[o, 0]} {garden[o, 1]} {garden[o, 2]} {garden[o, 3]} {garden[o, 4]} {garden[o, 5]}" +
                                    $" {garden[o, 6]} {garden[o, 7]} {garden[o, 8]}");
                            }
                            Thread.Sleep(300);
                        }
                    }
                }
                else                            //worker2
                {
                    for (int i = 0; i <= len - 1; i++)
                    {
                        for (int j = 0; j <= len - 1; j++)
                        {
                            char curr_gar = garden[i, j];
                            if (curr_gar == 0)
                            {
                            if (plan[i, j] == 'x')
                                garden[i, j] = 'x';
                            else
                                garden[i, j] = '.';
                        }
                            for (int o = 1; o < 9; o++)
                            {
                                Console.WriteLine($"{garden[o, 0]} {garden[o, 1]} {garden[o, 2]} {garden[o, 3]} {garden[o, 4]} {garden[o, 5]}" +
                                    $" {garden[o, 6]} {garden[o, 7]} {garden[o, 8]}");
                            }
                            Thread.Sleep(300);
                        }
                    }
                }
            
            Console.ReadKey();
        }        
    }
}



