using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ConsoleApplication1
{
   public class Calendar
    {

      public  SortedSet<Slot> slots = new SortedSet<Slot>(new DateComparer());

      public Calendar() { }

        public IEnumerable<Slot> FilterBy(Func<Slot,bool> Query)
        {
            return slots.Where(Query);
        
        }

        public IEnumerable<Slot> FilterByType(string type)
        {
            return FilterBy((t) => t.GetType().Name == type);
        }

        public IEnumerable<Slot> FilterByDateAndType(DateTime date_start, DateTime date_finish, string type)
        {
            return FilterBy((t) => t.Allocated_Start.Date >= date_start.Date &&
                            t.Allocated_Finish.Date <= date_finish.Date &&
                            t.GetType().Name == type);            
        }

        public List<Absence> FilterAbsences(DateTime date_start, DateTime date_finish)
        {
            IEnumerable<Slot> slots =  FilterBy((t) => t.Allocated_Start.Date >= date_start.Date &&
                            t.Allocated_Finish.Date <= date_finish.Date &&
                            t.GetType().Name == "Absence");

            List<Absence> list = new List<Absence>();
            foreach (Slot s in slots)
            {
                list.Add((Absence)s);
            }

            return list;

        }

        public List<Absence> FilterAbsenceByType(Absence.AbsenceType type, DateTime date_start, DateTime date_finish)
        {
            List<Absence> a = FilterAbsences(date_start, date_finish);
            List<Absence> ab = new List<Absence>();
            foreach (Absence s in a)
            {
                if (s._type == type)
                {
                    ab.Add((Absence)s);
                }
            }
            return ab;
        }

        public int GetMinutesByType(DateTime date_start, DateTime date_finish, string type)
        {
            return FilterByDateAndType(date_start, date_finish, type).Sum((t) => t.Duration().Minutes);
        }

        public int GetHoursByType(DateTime date_start, DateTime date_finish, string type)
        {

            return FilterByDateAndType(date_start, date_finish, type).Sum((t) => t.Duration().Hours);
        }

        public int GetDaysByType(DateTime date_start, DateTime date_finish, string type)
        {

            return FilterByDateAndType(date_start, date_finish, type).Sum((t) => t.Duration().Days);
        }

       

      }


}
