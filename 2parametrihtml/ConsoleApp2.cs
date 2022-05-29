using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    /*
     * Cerinta:
     * Implementati o aplicatie care sa primeasca 2 parametrii la rularea din linia de comanda. Aplicatia va crea un nou proces
     * ce va rula aceeasi aplicatie. Procesul initial va afisa la consola primul parametru si va crea un director cu numele parametrului,
     * al doilea process va afisa la consola cel de-al doilea parametru si va crea un fisier .html in care va scrie valoarea parametrului
     * iar dupa crearea fisierului va deschide fisierul intr-un browser in proces separat. Rulati aplicatia din linia de comanda cu parametrii
     * numele respectiv prenumele dvs.
     * 
     */
    internal class Program
    {

        static void Main(string[] args)
        {
            Process[] localProcesesses = Process.GetProcesses();
            int ok = 0;
            foreach (Process p in localProcesesses.OrderBy(x => x.ProcessName))
            {
                if (p.ProcessName == "ConsoleApp2")
                {
                    ok++;
                }
            }
            if (ok == 1)
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                Console.WriteLine(a);
                Directory.CreateDirectory(a);
                string ab = a + " " + b;
                Process.Start(@"C:\Users\Alex\Desktop\Scoala\anul-3\semestru-2\SO\lab\ConsoleApp2\bin\Debug\ConsoleApp2.exe", ab);
                Console.ReadLine();

            }
            else if (ok == 2) // process 2
            {
                Console.WriteLine("Process 2");
                if (args.Length >= 1)
                {
                    string a = args[0];
                    string b = args[1];
                    Console.WriteLine(b);
                    string fullPath = string.Format("{0}{1}{2}", Directory.GetCurrentDirectory(), Path.DirectorySeparatorChar, a);
                    string fName = b + ".html";
                    fullPath = Path.Combine(fullPath, fName);

                    string[] lines = { "<html>", "<body>", "<div>" + b +  "</div>", " </body > ", " </html > " };
                    File.WriteAllLines(fullPath, lines);
                    Process.Start("chrome.exe", fullPath);
                    Console.ReadLine();


                }

            }
            Console.ReadLine();
        }
    }
}
