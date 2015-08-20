using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = "*.txt";
            string sourcePath = @"C:\Users\gyerden\Desktop\CD Burn\TestArchive";
            string targetPath = @"C:\Users\gyerden\Desktop\TestArchive";

            string sourceFile = System.IO.Path.Combine(sourcePath,fileName);
            string destFile= System.IO.Path.Combine(targetPath, fileName);
            DateTime dtDate = DateTime.Now.Subtract(TimeSpan.FromDays(45));

            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                foreach (string file in files)
                {
                    DateTime creationTime = File.GetLastWriteTime(file);
                    if (creationTime <= dtDate)
                    {
                        fileName = System.IO.Path.GetFileName(file);
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Move(file, destFile);
                    }
                    else
                    {
                        Console.WriteLine("Problem in foreach loop");
                    }
                   
                }


            }
            else
            {
                Console.WriteLine("Source path doesn't exist.");
            }
          
            Console.WriteLine("Press any Key to Exit");
            Console.ReadKey();
        }
    }
}
