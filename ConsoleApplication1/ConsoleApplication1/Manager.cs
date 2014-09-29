using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Manager : Resource
    {
       public List<Employee> EmployeesList;
        
       public Manager(int idManager, string name, int numHours) : base (idManager, name, numHours)
        {
              EmployeesList = new List<Employee>();
        }

        

        public Employee GetEmployee(int IdEmployee)
        {
            foreach (var Employee in EmployeesList)
            {
                if (Employee._id_Resource == IdEmployee)
                    return Employee;
            }
            return null;
        }


    }
}
