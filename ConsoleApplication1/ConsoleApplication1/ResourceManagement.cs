using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    [Serializable]
    public class ResourceManagement
    {

        int IdCount {get; set;}
        public Dictionary<int, Resource> Resources; 

      
        public ResourceManagement()
        {
            Resources = new Dictionary<int, Resource>();
        }

        public void AddResource(Resource R)
        {

            Resources.Add(Increment(), R);
        }

        public int Increment()
        {

            return ++IdCount;
        
        }

        public IEnumerable<Tuple<Resource, int>> GetWorkingTimeByMinutes(DateTime date)
        {
            foreach (var res in Resources)
            {
               int time = res.Value.Calendar
                    .FilterBy((t) => t.Allocated_Start.Date == date.Date && 
                     t.GetType().Name == "Work")
                    .Sum((t) => t.Duration().Minutes);

               yield return new Tuple<Resource, int>(res.Value,time);
            }      
        }

        public void ListAllManagers()
        {
            foreach (var Resource in Resources)
                if (Resource.Value.GetType() == typeof(Manager))
                {
                    Console.WriteLine("  ID: {0}\tName: {1}", Resource.Value._id_Resource, Resource.Value._name);
                }
        }

        public void ListAllEmployees()
        {
            foreach (var Resource in Resources)
                if (Resource.Value.GetType() == typeof(Employee))
                {
                    Console.WriteLine("  ID: {0}\tName: {1}", Resource.Value._id_Resource, Resource.Value._name);
                }
        }
        public void ListEmployeesByManager()
        {
            ListAllManagers();
            Console.WriteLine("Select Manager ID to display his Employees");
            int ManagerId = Convert.ToInt32(Console.ReadLine());

            Resource man;
            Resources.TryGetValue(ManagerId, out man);
            if (man != null)
            {
              //  foreach (var Employee in m.EmployeesList)
              //      Console.WriteLine("  ID: {0}\tName: {1}", Resource.Value._id_Resource, Resource.Value._name);
            }
                
            
        }

    }
   
    public class ResourcesType
        {
           public int id;
           public Resource resource;
        }
}
