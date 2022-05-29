using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
internal class Program
{
private static int X = 1;
private static Mutex mut = new Mutex();
private static int[] C = new int[10];
private static string fullPath = @"C:\Studenti\JidovuOctavian\ConsoleApp1\b.txt";

public static void ThreadFunction(object parameter)
{
mut.WaitOne();
int i = (int)parameter;
if ((int)parameter % 2 == 0)
{
X--;
C[i] = X;
}
else
{
X++;
C[i] = X;

}
File.AppendAllLines(fullPath, new string[] { X.ToString() });
Thread.Sleep(1);

mut.ReleaseMutex();
}
static void Main(string[] args)
{
string fullPath = @"C:\Studenti\JidovuOctavian\ConsoleApp1\b.txt";
Thread[] childThreads = new Thread[10];
string[] file = new string[10];
for (int i = 0; i < 10; i++)
{
childThreads[i] = new Thread(ThreadFunction);
childThreads[i].Start(i);
}
for (int i = 0; i < 10; i++)
{
childThreads[i].Join();
}
for (int i = 0; i < 10; i++)
{
file[i] = string.Format("{0}", C[i]);

}
//File.WriteAllText(fullPath, String.Empty); //stergere continut din a.txt
//scriere in fisierul a.txt
Process.Start("Notepad.exe", fullPath); //deschidere fisier cu Notepad
Console.ReadLine();

}
}
}
