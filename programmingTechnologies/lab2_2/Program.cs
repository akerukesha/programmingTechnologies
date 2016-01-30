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
        //необходимо создать метод F1, который вызывается в Main
        private static void F1()
        {   //считываем значения с input.txt
            FileStream fs = new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            //значения считываются в виде строки, которую необходимо разбить
            string line = sr.ReadLine();
            string[] arr = line.Split(' ');
            //задаются начальные значения для максимума и минимума
            int max = 0;
            int min = 1000;
            //берется каждое значение массива
            for (int i = 0; i < arr.Length; i++)
            {   //конвертируется с типа string в тип integer
                int currentNumber = int.Parse(arr[i]);
                if (currentNumber > max)
                {
                    max = currentNumber;
                }
                if (currentNumber < min)
                {
                    min = currentNumber;
                }
            }

            Console.WriteLine("Maximum: " + max + "\nMinumum: " + min);
            //закрывается файл
            sr.Close();
            fs.Close();
        }
    }
}
