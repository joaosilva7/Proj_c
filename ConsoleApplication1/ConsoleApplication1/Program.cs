using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ResourceManagement rm = new ResourceManagement();
            
            IOStreamReader sr = new IOStreamReader("dbinitial.xml");
           
            // sr.Load();
            
            
            Console.WriteLine("Criou a DB");

        
            rm = sr.createDB();
            sr.Save(rm);
        }
    }
}
