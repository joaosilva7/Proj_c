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
        public List<Resource> Resources; 

      
        public ResourceManagement()
        {
            Resources = new List<Resource>();
        }

        public void AddResource(Resource R)
        {

            Resources.Add(R);
            Increment();
        }

        public int Increment()
        {

            return ++IdCount;
        
        }

        public IEnumerable<Tuple<Resource, int>> GetWorkingTimeByMinutes(DateTime date)
        {
            foreach (var res in Resources)
            {
               int time = res.Calendar
                    .FilterBy((t) => t.Allocated_Start.Date == date.Date && 
                     t.GetType().Name == "Work")
                    .Sum((t) => t.Duration().Minutes);

               yield return new Tuple<Resource, int>(res,time);
            }      
        }
        

    }
   
}
