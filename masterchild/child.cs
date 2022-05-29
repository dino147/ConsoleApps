using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Child
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread.Sleep(1000);
            Console.WriteLine("Process Child");
            if(args.Length > 0)
            {
                Console.WriteLine(args[0]);
                Directory.CreateDirectory(args[0]);
                string filename = "test" + args[0] + ".txt";
                string path = Path.Combine(args[0], filename);
                File.Create(path);
            }

            Console.ReadLine();
            
        }
    }
}
