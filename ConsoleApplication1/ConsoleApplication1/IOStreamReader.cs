using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Collections;

namespace ConsoleApplication1
{
    public class IOStreamReader
    {
        XmlSerializer serializer;
        string _filename;
       
        
        public IOStreamReader(string filename)
        {
            _filename = filename;
            
        }

        public void Save (ResourceManagement rm)
        {
            
            {
                using (TextWriter writer = new StreamWriter(_filename))
                {
                    //Work w = new Work(DateTime.Now, DateTime.Now, "yo");
                    serializer = new XmlSerializer(typeof(ResourceManagement));
                    serializer.Serialize(writer, rm);
                }
            }

        }

        public ResourceManagement Load()
        {
            ResourceManagement resMan;
            using (FileStream loader = new FileStream(_filename, FileMode.OpenOrCreate))
            {
                resMan = (ResourceManagement)serializer.Deserialize(loader);
            }

            return resMan;
        }


        public ResourceManagement createDB()
        {
            ResourceManagement rm = new ResourceManagement();
            int j = 1;
            List<Manager> ManagersList = new List<Manager>();
            List<Employee> EmployeesList = new List<Employee>();

            String[] Names = new String []{"Maria", "Manel", "Zé", "Tó", "Sara"};

            int numManagers = 10;
            int numEmployees = 50;
            Random rnd = new Random();
            int a;
            
            for (int i = 0; i < numManagers; i++)
            {
                a = rnd.Next(5);
                Manager m = new Manager(j, Names[a], 10);
                j++;
                Console.WriteLine("manager" + m._id_Resource + m._name);
                ManagersList.Add(m);
          
            }


            for (int i = 0; i < numEmployees; i++)
            {
                a = rnd.Next(5);
                Employee e = new Employee(j, Names[a], 8);
                Console.WriteLine("employee" + e._id_Resource + e._name);
                a = rnd.Next(numManagers);
                Manager man = ManagersList.ElementAt(a);
                
                man.EmployeesList.Add(e);
             //   Console.Write(" teste man: employeeId: {0}, EmployeeName: {1}", man.EmployeesList.ElementAt(0)._id_Resource, man.EmployeesList.ElementAt(0)._name);

                    j++;
                    rm.AddResource(e._id_Resource, e);
                    rm.Increment();
            }

            foreach (var manager in ManagersList)
            {
                foreach (var employee in manager.EmployeesList)
                {
                    DateTime start = DateTime.Today.AddDays(new Random().Next(7)).AddHours(8);
                    DateTime finish = start.AddHours(new Random().Next(10));
                    Work slot = new Work(start, finish);
                    manager.Calendar.slots.Add(slot);
                    employee.Calendar.slots.Add(slot);

                    if (new Random().Next(5) <= 2)
                    {
                        DateTime start2 = DateTime.Today.AddDays(new Random().Next(7)).AddHours(8);
                        DateTime finish2 = start.AddHours(new Random().Next(10));
                        Absence.AbsenceType ab = Absence.AbsenceType.Holiday;
                        Absence slot2 = new Absence(start2, finish2, ab);
                        manager.Calendar.slots.Add(slot2);
                        employee.Calendar.slots.Add(slot2);
                    }

                }
                rm.AddResource(manager._id_Resource, manager);
                rm.Increment();
            }
            return rm;
        
        }

        public void ListAllResources(IEnumerable<Resource> ListRes)
        {
            foreach (var resource in ListRes)
            {
                Console.WriteLine(" ID: {0}\t\tName: {1}", resource._id_Resource, resource._name);
            }
        }

    }
}
