using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Work : Slot
    {
        public DateTime Done_Start { get; set; }
        public DateTime Done_Finish { get; set; }

        public Work()
        {
        }

           public Work(DateTime Start, DateTime Finish, String Description = null) : base( Start, Finish, Description)
        {
           
        }

        
        public override void UpdateSlot(DateTime Start, DateTime Finish, string Desc)
        {
            base.UpdateSlot(Done_Start, Done_Finish, Desc = null);
          }

        public void SetDoneTime(DateTime start, DateTime finish)
        {
            Done_Start = start;
            Done_Finish = finish;
        
        }

        public override TimeSpan Duration()
        {
            return Done_Finish.Subtract(Done_Start);
        }

        public TimeSpan GetAllocatedTime()
        {
            return Allocated_Finish.Subtract(Allocated_Start);
        }

        public TimeSpan CompareTimes()
        {
            return GetAllocatedTime().Subtract(Duration());
        
        }

    }
}


