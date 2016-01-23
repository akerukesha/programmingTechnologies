using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            F1();
        }

        private static void F1()
        {
            FileStream fs = new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();
            string[] arr = line.Split(' ');

            int max = 0;
            int min = 0;


        }
    }
}
