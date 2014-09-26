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
        public List<ResourcesType> Resources; 

      
        public ResourceManagement()
        {
            Resources = new List<ResourcesType>();
        }

        public void AddResource(Resource R)
        {
            ResourcesType Rt = new ResourcesType();
            Rt.id = IdCount;
            Rt.resource = R;

            Resources.Add(Rt);
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
               int time = res.resource.Calendar
                    .FilterBy((t) => t.Allocated_Start.Date == date.Date && 
                     t.GetType().Name == "Work")
                    .Sum((t) => t.Duration().Minutes);

               yield return new Tuple<Resource, int>(res.resource,time);
            }      
        }
        

    }
   
    public class ResourcesType
        {
           public int id;
           public Resource resource;
        }
}
