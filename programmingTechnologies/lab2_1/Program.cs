using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{   //поиск файлов в каждой папке
    class Program
    {  
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            //F4(@"C:\xampp\htdocs\application");
            //F5(@"C:\xampp\htdocs\application");
            F6(@"C:\xampp\htdocs\application");
        }

        private static void F6(string path)
        {
            Stack<string> dirs = new Stack<string>(30);
            dirs.Push(path);
            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs = Directory.GetDirectories(currentDir);
                foreach (string str in subDirs)
                {
                    Console.WriteLine(str + ": " + Directory.GetFiles(str).Length);
                    dirs.Push(str);
                }
            }
        }

        //использую SearchOption.AllDirectories
        private static void F5(string path)
        {
            //var stack = new Stack<DirectoryInfo>();
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo[] dirs = directory.GetDirectories("*", SearchOption.AllDirectories);
            for (int i = 0; i < dirs.Length; i++)
            {
                Console.WriteLine(dirs[i].FullName + ": " + dirs[i].GetFiles().Length);
            }
        }
        //рекурсивный метод
        private static void F4(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            Console.WriteLine(directory.FullName + ": " + directory.GetFiles().Length);
            DirectoryInfo[] directories = directory.GetDirectories();
            for(int i = 0; i < directories.Length; i++)
            {
                F4(directories[i].FullName);
            }
        }

        /*private static void F3()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\xampp\htdocs\application");
            var x = directory.GetDirectories();
            foreach(DirectoryInfo t in x)
            {
                Console.WriteLine(t.FullName + ": " + t.GetFiles().Length);
            }
        }

        private static void F2()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\xampp\htdocs\application");
            var x = directory.GetDirectories();
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i].FullName + ": " + x[i].GetFiles().Length);
            }
        }

        private static void F1()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\xampp\htdocs\application");
            Console.WriteLine(directory.GetFiles().Length);
            Console.WriteLine(directory.GetDirectories().Length);
        }*/
    }
}
