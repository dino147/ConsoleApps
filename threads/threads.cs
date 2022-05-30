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
            Console.WriteLine("Scrie numele fisierului txt");
            string file = Console.ReadLine();
            Thread[] childThreads = new Thread[8];
            //Thread[] decThreads = new Thread[4];
            for (int i = 0; i < 8; i++)
            {
                if(i % 2 == 1)
                    childThreads[i] = new Thread(incFunction);
                else 
                    childThreads[i] = new Thread(decFunction);

                childThreads[i].Start(file);
                //File.AppendText(args[0], A);
                //File.AppendAllText(args[0], A.ToString());
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
