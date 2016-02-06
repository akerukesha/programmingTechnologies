using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_additional
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\xampp\htdocs\application";
            DirectoryInfo dir = new DirectoryInfo(path);

            List<FileSystemInfo> items = new List<FileSystemInfo>();
            items.AddRange(dir.GetDirectories());
            items.AddRange(dir.GetFiles());

            int index = 0;

            while (true)
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    if (items[i].GetType() == typeof(FileInfo))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine(items[i].Name);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }


                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index < items.Count - 1) index++;
                        break;
                    case ConsoleKey.Enter:
                        if (items[index].GetType() == typeof(DirectoryInfo))
                        {
                            path = items[index].FullName;
                            dir = new DirectoryInfo(path);
                            items.Clear();
                            items.AddRange(dir.GetDirectories());
                            items.AddRange(dir.GetFiles());
                            index = 0;
                        }
                        break;
                    case ConsoleKey.Escape:
                        string currentDir = Directory.GetParent(items[index].FullName).ToString();
                        if (currentDir == @"C:\xampp\htdocs\application")
                        {
                            break;
                        }
                        path = Directory.GetParent(currentDir).ToString();
                        dir = new DirectoryInfo(path);
                        items.Clear();
                        items.AddRange(dir.GetDirectories());
                        items.AddRange(dir.GetFiles());
                        index = 0;
                        break;

                }
                Console.Clear();
            }
        }
    }
}
