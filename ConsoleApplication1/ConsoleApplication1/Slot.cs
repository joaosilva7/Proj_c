using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public abstract class Slot
    {
        public DateTime Allocated_Start { get; set; }
        public DateTime Allocated_Finish { get; set; }
        public String Description { get; set; }

        public Slot()
        {
        }

        public Slot(DateTime Start, DateTime Finish, String Description = null)
        {
            this.Allocated_Start = Start;
            this.Allocated_Finish = Finish;
            this.Description = Description;
        }

        public virtual void UpdateSlot(DateTime Start, DateTime Finish, String Description)
        {
            this.Allocated_Start = Start;
            this.Allocated_Finish = Finish;
            this.Description = Description;
        }

        public virtual TimeSpan Duration()
        {
            return Allocated_Finish.Subtract(Allocated_Start);
        }
    }
}
