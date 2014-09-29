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
            int userInput2 = 0;
            do
            {
                userInput = DisplayMenu();

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("List all Managers");
                        IEnumerable<Resource> ListMan = rm.GetList("Manager");
                        sr.ListAllResources(ListMan);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("List all Emplyees");
                        IEnumerable<Resource> ListEmp = rm.GetList("Employee");
                        sr.ListAllResources(ListEmp);
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("List Employees by Manager");
                        IEnumerable<Resource> ListManagers = rm.GetList("Manager");
                        sr.ListAllResources(ListManagers);
                        Console.WriteLine("Insert Manager ID to display his Employees");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Manager res = (Manager)rm.GetResource(id);
                        sr.ListAllResources(res.EmployeesList);
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Insert Employee Id");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        Employee emp = (Employee)rm.GetResource(id2);
                        Console.WriteLine("Employee Name: {0}\t\t ID: {1}", emp._name, emp._id_Resource);
                        userInput2 = EmployeeDetailsDisplay();
                        do{
                        switch (userInput2)
                        {
                            case 1:
                                Console.Clear();
                                int type = SlotTypeDisplay();
                                if(type <= 0 || type > 4) break;
                                Console.WriteLine("Insert Initial Date by this format: yy,mm,dd,hh");
                                String dt1 = Console.ReadLine();
                                Console.WriteLine("Insert Final Date by this format: yy,mm,dd,hh");
                                String dt2 = Console.ReadLine();
                                emp.AddSlot(type, dt1, dt2);
                                Console.WriteLine("Slot added successfully...");
                                break;
                            case 2:
                                Console.Clear();
                                DateTime dt = DateTime.Now;
                                DateTime dtfinal = dt.AddDays(30);


                                break;

                        }
                        
                        }while(userInput2 != 0);
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
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
            Console.WriteLine("4 - Employee Details");
            Console.WriteLine("5 - Add Slot");
            Console.WriteLine("6 - Search");

            var result = Console.ReadLine();
            return Convert.ToInt32(result);

        }

        public static int EmployeeDetailsDisplay()
        {
            Console.WriteLine(" EMPLOYEE DETAILS ");
            Console.WriteLine();
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Add Slot");
            Console.WriteLine("2 - Show Next 30 Days Calendar");
            Console.WriteLine("3 - Show Work Calendar");
            Console.WriteLine("4 - Show All Absence Calendar");
            Console.WriteLine("5 - Show Holidays Calendar");
            Console.WriteLine("6 - Show Sick Calendar");
            Console.WriteLine("7 - Show Not Justified Calendar");
           

            var result = Console.ReadLine();
            return Convert.ToInt32(result);

        }

        public static int SlotTypeDisplay()
        {
            Console.WriteLine(" SLOT TYPE ");
            Console.WriteLine();
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Work Slot");
            Console.WriteLine("2 - Holiday Slot");
            Console.WriteLine("3 - Sick Slot");
            Console.WriteLine("4 - NotJustified Slot");

            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }


    }
}
