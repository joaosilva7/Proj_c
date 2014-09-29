using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class DateComparer : IComparer<Slot>
    {
        public DateComparer() { }

        public int Compare(Slot x, Slot y)
        {
            // if they are equal return 0
            if (x.Equals(y))
                return 0;

            int result = x.Allocated_Start.CompareTo(y.Allocated_Start);
            return (result == -1) ? -1 : 1;
        }
    }
}