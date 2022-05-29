using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start master!");

            Process[] childProcesesses = new Process[10];
            

            for (int i = 0; i < 10; i++)
             {
                 childProcesesses[i] = Process.Start(@"C:\Users\Alex\Desktop\Scoala\anul-3\semestru-2\SO\lab\Master\Child\bin\Debug\Child.exe", i.ToString());
             }
            

            Console.WriteLine("Stop master!");
            Console.ReadLine();
        }
    }
}
