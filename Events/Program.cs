using Generics.Models;
using Generics.WithGenerics;
using Generics.WithoutGenerics;
using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main()
        {
            //Generics give you actual types. 
            //For example this List<T> is locked in with a type of int and it can't be changed later on.
            //List<int> ages = new List<int>();
            //ages.Add(23);

            Console.ReadLine();

            DemonstrateTextFileStorage();

            Console.WriteLine();
            Console.WriteLine("Press enter to shut down...");
            Console.ReadLine();
        }

        private static void DemonstrateTextFileStorage()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            string peopleFile = @"C:\Users\mindaugas.pikelis\source\repos\Generics\people.txt";
            string logFile = @"C:\Users\mindaugas.pikelis\source\repos\Generics\logs.txt";

            PopulateLists(people, logs);

            /* New way of doing things - generics */

            GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

            var newPeople = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);

            foreach (var p in newPeople)
            {
                Console.WriteLine($"{ p.FirstName} { p.LastName } (IsAlive = { p.IsAlive })");
            }

            var newLogs = GenericTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);

            foreach (var log in newLogs)
            {
                Console.WriteLine($"{ log.ErrorCode }: { log.Message } at { log.TimeOfEvent.ToShortTimeString() })");
            }


            /* Old way of doing things - non-generics */
            //OriginalTextFileProcessor.SavePeople(people, peopleFile);

            //var newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);

            //foreach (var p in newPeople)
            //{
            //    Console.WriteLine($"{ p.FirstName} { p.LastName } (IsAlive = { p.IsAlive })");
            //}
        }

        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { FirstName = "Tim", LastName = "Corey" });
            people.Add(new Person { FirstName = "Sue", LastName = "Storm", IsAlive = false });
            people.Add(new Person { FirstName = "Greg", LastName = "Olsen" });

            logs.Add(new LogEntry { Message = "I blew up", ErrorCode = 9999 });
            logs.Add(new LogEntry { Message = "I'm too awesome", ErrorCode = 1337 });
            logs.Add(new LogEntry { Message = "I was tired", ErrorCode = 2222 });
        }
    }
}
