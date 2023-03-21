using NUnit.Framework;
using Schedule;
using System;
using System.Collections.Generic;

namespace TestSchedule
{
    public class Tests
    {
        Module module1 = new Module("test1", 5, 11);
        Module module2 = new Module("test2", 5, 12);
        Module module3 = new Module("test3", 5, 13);
        Module module4 = new Module("test4", 5, 14);
        Module module5 = new Module("test5", 5, 15);
        List<Module> list_sorted = new();
        List<Module> list_unsorted = new();
        [SetUp]
        public void Setup()
        {
            list_sorted.Clear();
            list_unsorted.Clear();
            list_sorted.Add(module1);
            list_sorted.Add(module2);
            list_sorted.Add(module3);
            list_sorted.Add(module4);
            list_sorted.Add(module5);
            list_unsorted.Add(module2);
            list_unsorted.Add(module1);
            list_unsorted.Add(module3);
            list_unsorted.Add(module5);
            list_unsorted.Add(module4);
        }

        [Test]
        public void TestModuleSort()
        {
            Setup();
            list_unsorted.Sort(Module.CompareByCoef);
            Assert.AreEqual(list_sorted[0].coef, list_unsorted[0].coef);
            Assert.AreEqual(list_sorted[1].coef, list_unsorted[1].coef);
            Assert.AreEqual(list_sorted[2].coef, list_unsorted[2].coef);
            Assert.AreEqual(list_sorted[3].coef, list_unsorted[3].coef);
            Assert.AreEqual(list_sorted[4].coef, list_unsorted[4].coef);
        }

        [Test]
        public void TestModuleCoef()
        {
            Setup();
            Assert.AreEqual(3.0, Math.Round(module5.coef),1);
            Assert.AreEqual(2.8, Math.Round(module4.coef),1);
            Assert.AreEqual(2.6, Math.Round(module3.coef),1);
            Assert.AreEqual(2.4, Math.Round(module2.coef),1);
            Assert.AreEqual(2.2, Math.Round(module1.coef),1);
        }

        [Test]
        public void TestSchedulerUnsorted()
        {
            Setup();
            Scheduler scheduler = new Scheduler(20, list_unsorted);
            Assert.AreEqual(54, scheduler.Schedule());
        }

        [Test]
        public void TestSchedulerSorted()
        {
            Setup();
            Scheduler scheduler = new Scheduler(20, list_sorted);
            Assert.AreEqual(54, scheduler.Schedule());
        }
    }
}