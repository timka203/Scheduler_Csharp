using System;
using System.Collections.Generic;

namespace Schedule
{
    public class Module
    {
        public string name;
        public int time;
        public int num_of_questions;
        public float coef;

        public Module(string name, int time, int num_of_questions)
        {
            this.name = name;
            this.num_of_questions = num_of_questions;
            this.time = time;
            CalculateCoef();
        }
        public static int CompareByCoef(Module module1, Module module2)
        {
            return module1.coef.CompareTo(module2.coef);
        }
        void CalculateCoef()
        {
            this.coef = (float)num_of_questions / (float)time;
        }
    }
    public class Scheduler
    {
        int time_left;
        int question_cheked = 0;
        List<Module> modules = new();
        List<Module> used_modules = new();

        public Scheduler(int time, List<Module> modules)
        {
            this.time_left = time;
            this.modules = modules;
        }

        public int Schedule()
        {
            Module used_module;
            modules.Sort(Module.CompareByCoef);
            modules.Reverse();
            modules.ForEach(e => Console.WriteLine(e.name + " " + e.coef + " \n"));
            while ((used_module = modules.Find(x => x.time <= time_left)) != null)
            {
                modules.Remove(used_module);
                used_modules.Add(used_module);
                question_cheked += used_module.num_of_questions;
                time_left -= used_module.time;
            }
            PrintSchedule();
            return question_cheked;
        }
        void PrintSchedule()
        {
            Console.WriteLine("Modules to learn {0} :", used_modules.Count);
            used_modules.ForEach(e => Console.WriteLine("\n{0}\tNumber of questions:{1}", e.name, e.num_of_questions));
            Console.WriteLine("\nTotal number of questions:{0}", question_cheked);
            Console.WriteLine("\nFree hours after studying:{0}", time_left);
            if (time_left > 0 && modules.Count > 0)
            {
                Console.WriteLine("\nModule that could be covered partially:{0}\n ",modules[0].name);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Module module1 = new Module("test1", 2, 8);
            Module module2 = new Module("test2", 5, 12);
            Module module3 = new Module("test3", 5, 13);
            Module module4 = new Module("test4", 5, 14);
            Module module5 = new Module("test5", 5, 15);
            List<Module> list_unsorted = new();
            list_unsorted.Add(module2);
            list_unsorted.Add(module1);
            list_unsorted.Add(module3);
            list_unsorted.Add(module5);
            list_unsorted.Add(module4);
            Scheduler scheduler = new Scheduler(20, list_unsorted);
            scheduler.Schedule();

        }
    }
}
