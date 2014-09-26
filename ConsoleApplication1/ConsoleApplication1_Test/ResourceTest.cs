using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using ConsoleApplication1;

namespace ConsoleApplication1_Test
{

    [TestClass]
    public class ResourceTest : SetUpTests
    {
        Employee employee;
        Manager manager;

        public override void SetUp()
        {
            base.SetUp();
            employee = new Employee(1, "John Doe", 8);
            manager = new Manager(2, "André", 10);
            employee.Calendar = base.calendar;

        }

        [TestMethod]
        public void GetWorkDays()
        {
            SetUp();
            DateTime start = DateTime.Today.AddDays(0);
            DateTime finish = DateTime.Today.AddDays(5);

            Assert.AreEqual(10, employee.GetWorkDays(start, finish));

        }

        [TestMethod]
        public void GetWorkHours()
        {
            SetUp();
            DateTime start = DateTime.Today.AddHours(0);
            DateTime finish = DateTime.Today.AddHours(5);

            Assert.AreEqual(20, employee.GetWorkHours(start, finish));

        }

        [TestMethod]
        public void GetHolidaysDays()
        {
            SetUp();
            DateTime start = DateTime.Today.AddDays(0);
            DateTime finish = DateTime.Today.AddDays(5);

            Assert.AreEqual(5, employee.GetHolidayDays(start, finish));

        }

        [TestMethod]
        public void GetSickDays()
        {
            SetUp();
            DateTime start = DateTime.Today.AddDays(0);
            DateTime finish = DateTime.Today.AddDays(5);

            Assert.AreEqual(5, employee.GetSickDays(start, finish));

        }

        [TestMethod]
        public void GetAbsenceDays()
        {
            SetUp();
            DateTime start = DateTime.Today.AddDays(0);
            DateTime finish = DateTime.Today.AddDays(5);

            Assert.AreEqual(5, employee.GetAbsenceDays(start, finish));

        }

    }
}