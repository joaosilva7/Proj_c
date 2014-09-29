using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ConsoleApplication1;

namespace ConsoleApplication1_Test
{
    [SetUpFixture]
    public class SetUpTests
    {
        public Calendar calendar;

        [SetUp]
        public virtual void SetUp()
        {
            calendar = new Calendar();
            for (int i = 0; i < 10; i++)
            {
                DateTime date_start = DateTime.Now.AddDays(i);
                DateTime date_finish = DateTime.Now.AddDays(i+1);

                Absence holidays = new Absence(date_start, date_finish, Absence.AbsenceType.NotJustified, "doente");

                Work slot = new Work(date_start, date_finish, "trabalho feito");
                slot.SetDoneTime(date_start, date_finish);

                DateTime dstart = DateTime.Now.AddHours(i);
                DateTime dfinish = DateTime.Now.AddHours(i + 1);
                Work slot_1 = new Work(dstart, dfinish, "trabalharam mais");

                slot_1.SetDoneTime(dstart, dfinish);

                calendar.slots.Add(holidays);
                calendar.slots.Add(slot_1);
            }

        }

    }

    
}
