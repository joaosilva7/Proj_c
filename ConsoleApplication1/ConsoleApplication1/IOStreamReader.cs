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
                rm.AddResource(m);
            }


            for (int i = 0; i < numEmployees; i++)
            {
                a = rnd.Next(5);
                Employee e = new Employee(j, Names[a], 8);
                Console.WriteLine("employee" + e._id_Resource + e._name);

                ManagersList.ElementAt(new Random().Next(numManagers)).EmployeesList.Add(e);
                    j++;
                    rm.AddResource(e);
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
            }
            return rm;
        
        }
    }
}
