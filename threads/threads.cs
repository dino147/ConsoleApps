using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cojocaru_Alex_Colocviu
{
    internal class Program
    {
        static float A = 0;
        private static Mutex mut = new Mutex();
        static void Main(string[] args)
        {
            int K = 8;
            Console.WriteLine("Scrie numele fisierului txt");
            string file = Console.ReadLine();
            Thread[] childThreads = new Thread[K];
            //Thread[] decThreads = new Thread[4];
            for (int i = 0; i < K; i++)
            {
                if(i % 2 == 1)
                    childThreads[i] = new Thread(incFunction);
                else 
                    childThreads[i] = new Thread(decFunction);

                childThreads[i].Start(file);
               // if(childThreads[i].)
            }

            for (int i = 0; i < K; i++)
            {
                childThreads[i].Join();
            }

            Console.WriteLine("S-a executat threadul principal");
            Console.ReadLine();
        }

        public static void incFunction(object file)
        {
            mut.WaitOne();
            // sectiune critica
            A++;
            //Console.WriteLine(A);
            string[] lines = { A.ToString() };
            File.AppendAllLines((string)file, lines);
            mut.ReleaseMutex();
        }
        public static void decFunction(object file)
        {
            mut.WaitOne();
            // sectiune critica
            A--;
            //Console.WriteLine(A);
            string[] lines = { A.ToString() };
            File.AppendAllLines((string)file, lines);
            mut.ReleaseMutex();
        }

    }
}
