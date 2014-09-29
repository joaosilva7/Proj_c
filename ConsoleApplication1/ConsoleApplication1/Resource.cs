using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
  public abstract class Resource
    {
        public int _id_Resource;
        public string _name;
        public int _numHours;       
        public Calendar Calendar { get; set; }

        public Resource() { }

        public Resource(int idResource, string name, int numHours) 
        {
            _id_Resource = idResource;
            _name = name;
            _numHours = numHours;
            Calendar = new Calendar();            
        }

        public int GetAbsenceDays(DateTime start, DateTime finish)
        {
            return Calendar.FilterAbsenceByType(Absence.AbsenceType.NotJustified, start, finish)
                .Sum((t) => t.Duration().Days);
        }

        public int GetHolidayDays(DateTime start, DateTime finish)
        {
            return Calendar.FilterAbsenceByType(Absence.AbsenceType.Holiday, start, finish)
                .Sum((t) => t.Duration().Days);
        }

        public int GetSickDays(DateTime start, DateTime finish)
        {
            return Calendar.FilterAbsenceByType(Absence.AbsenceType.Sick, start, finish)
                .Sum((t) => t.Duration().Days);
        }

        public int GetWorkDays(DateTime start, DateTime finish)
        {
            return Calendar.GetDaysByType(start, finish, "Work");
        }

        public int GetAbsenceHours(DateTime start, DateTime finish)
        {
            return Calendar.GetHoursByType(start, finish, "Absence");
        }

        public int GetHolidayHours(DateTime start, DateTime finish)
        {
            return Calendar.GetHoursByType(start, finish, "Holiday");
        }

        public int GetSickHours(DateTime start, DateTime finish)
        {
            return Calendar.GetHoursByType(start, finish, "Sick");
        }

        public int GetWorkHours(DateTime start, DateTime finish)
        {
            return Calendar.GetHoursByType(start, finish, "Work");
        }
        
        public void AddSlot(int type, string initialDT, string finalDT)
        {
            DateTime dti = PrepareDate(initialDT);
            DateTime dtf = PrepareDate(finalDT);
            Slot slot;
            switch(id){
                case 1: 
                    slot = new Work(dti, dtf);
                    Calendar.slots.Add(slot);
                    break;
                case 2: 
                    slot = new Absence(dti, dtf, Absence.AbsenceType.Holiday);
                    Calendar.slots.Add(slot);
                    break;
                case 3: 
                    slot = new Absence(dti, dtf, Absence.AbsenceType.Sick);
                    Calendar.slots.Add(slot);
                    break;
                case 4: 
                    slot = new Absence(dti, dtf, Absence.AbsenceType.NotJustified);
                    Calendar.slots.Add(slot);
                    break;

            }

        }

        public DateTime PrepareDate(string date)
        {
            string[] values = date.Split(new char[] {','});
            DateTime dt = new DateTime(Convert.ToInt32(values[0]),Convert.ToInt32(values[1]),Convert.ToInt32(values[2]),Convert.ToInt32(values[3]), 0, 0);
            return dt;
        }
    }
}