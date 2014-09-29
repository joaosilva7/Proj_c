using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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

        public void AddResource(int id, Resource R)
        {
            Resources.Add(id, R);
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

        public IEnumerable<Resource> GetList(string type)
        {
            foreach (var res in Resources)
            {
                if (res.Value.GetType().Name == type)
                    yield return res.Value;
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

        public Resource GetResource(int id)
        {
            Resource man;
            Resources.TryGetValue(id, out man);
            return man;
            
        }

    }
   
}
