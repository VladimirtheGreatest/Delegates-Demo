using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesDemo
{
    class Program
    {
        public delegate bool FilterDelegate(Person p);
        //generic one
        public static Func<Person, Person> upperBoy = str => new Person {Name = str.Name.ToUpper(), Age = str.Age };
        static void Main(string[] args)
        {
            List<string> groups = new List<string>() { "Children", "Adults", "Seniors" };
            //Create 4 Person objects
            Person p1 = new Person() { Name = "John", Age = 41 };
            Person p2 = new Person() { Name = "Jane", Age = 69 };
            Person p3 = new Person() { Name = "Jake", Age = 12 };
            Person p4 = new Person() { Name = "Jessie", Age = 25 };

            //Create a list of Person objects and fill it
            List<Person> list = new List<Person>() { p1, p2, p3, p4 };


            var formattedListWithDelegate = list.Select(upperBoy).ToList();
            var convertedListUsingLinq = list.Select(x => new Person
            {
                Name = x.Name.ToUpper(),
                Age = x.Age
            }).ToList();

            //using delegate
            FilterGroups(groups, formattedListWithDelegate, true);
            //just to demonstrate it can be achieved by liq as well
            FilterGroups(groups, convertedListUsingLinq, false);
            Console.Read();
        }

        private static void FilterGroups(List<string> groups, List<Person> formattedListWithDelegate, bool isDelegate)
        {
            if (isDelegate)
            {
                Console.WriteLine("using delegate");
            }
            else
            {
                Console.WriteLine("using linq here");
            }

            foreach (var group in groups)
            {
                if (group == "Children")
                {
                    DisplayPeople(group, formattedListWithDelegate, IsChild);
                }
                if (group == "Adults")
                {
                    DisplayPeople(group, formattedListWithDelegate, IsAdult);
                }
                if (group == "Seniors")
                {
                    DisplayPeople(group, formattedListWithDelegate, IsSenior);
                }
            }
        }

        /// <summary>
        /// A method to filter out the people you need
        /// </summary>
        /// <param name="people">A list of people</param>
        /// <param name="filter">A filter</param>
        /// <returns>A filtered list</returns>
        static void DisplayPeople(string title, List<Person> people, FilterDelegate filter)
        {
            Console.WriteLine(title);

            foreach (Person p in people)
            {
                if (filter(p))
                {
                    Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
                }
            }

            Console.Write("\n\n");
        }

        //==========FILTERS===================
        static bool IsChild(Person p)
        {
            return p.Age < 18;
        }

        static bool IsAdult(Person p)
        {
            return p.Age >= 18;
        }

        static bool IsSenior(Person p)
        {
            return p.Age >= 65;
        }
    }
}
