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
           // sr.Save(rm);

            int userInput = 0;
            do
            {
                userInput = DisplayMenu();

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("List all Managers");
                        rm.ListAllManagers();
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("List all Emplyees");
                        rm.ListAllEmployees();
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("List Employees by Manager");
                        rm.ListEmployeesByManager();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            } while(userInput != 0);
        }

        public static int DisplayMenu()
        {
            Console.WriteLine(" RESOURCES MANAGER ");
            Console.WriteLine();
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - List all Managers");
            Console.WriteLine("2 - List all Employees");
            Console.WriteLine("3 - List Employees by Manager");
            Console.WriteLine("4 - Add Resource");
            Console.WriteLine("5 - Add Slot");
            Console.WriteLine("6 - Search");

            var result = Console.ReadLine();
            return Convert.ToInt32(result);

        }


    }
}
