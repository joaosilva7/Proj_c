using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   public class Absence : Slot
    {
        public enum AbsenceType {Holiday, Sick, NotJustified}
        public AbsenceType _type{get; set;}
        

        public Absence(DateTime Start, DateTime Finish, AbsenceType type, String Description = null)
            : base(Start, Finish, Description)
        {
            _type = type;
        }

       
   
    }
}
