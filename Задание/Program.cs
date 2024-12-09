using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Задание
{
    internal class Program
    {
        const int n = 10; 
        const int m = 10;
        static int[,] garden = new int[n, m];


        static void Main(string[] args)
        {
           
            Thread gardener1 = new Thread(Gardener1);
            Thread gardener2 = new Thread(Gardener2);

            gardener1.Start();
            gardener2.Start();

            gardener1.Join(); 
            gardener2.Join(); 

            PrintGarden();

            Console.ReadKey();

        }
        static void Gardener1()
        {
            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < m; j++)
                {
                    lock (garden) 
                    {
                        if (garden[i, j] == 0) 
                        {
                            garden[i, j] = 1; 
                            Thread.Sleep(20); 
                        }
                    }
                }
            }
        }

        static void Gardener2()
        {
            for (int i = n - 1; i >= 0; i--) 
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    lock (garden) 
                    {
                        if (garden[i, j] == 0) 
                        {
                            garden[i, j] = 2; 
                            Thread.Sleep(10); 
                        }
                    }
                }
            }
        }

        static void PrintGarden()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


    }

}

