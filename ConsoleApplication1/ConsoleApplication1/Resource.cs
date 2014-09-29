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

    }
}