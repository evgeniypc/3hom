using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace _3dom
{
    class Program
    {
        static void Main(string[] args)
        {
            TextHandler text = new TextHandler() { Path = @"C:\Users\Sony\source\repos\3dom\123\555.txt" };
            Task.WaitAll(text.CreatAlphabeticalFileWithData());

            Console.ReadLine();


        }
    }
}



    
