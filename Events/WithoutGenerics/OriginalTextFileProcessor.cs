using Generics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics.WithoutGenerics
{
    public static class OriginalTextFileProcessor
    {
        public static List<Person> LoadPeople(string filePath)
        {
            List<Person> output = new List<Person>();
            Person p;
            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            //remove the header row
            lines.RemoveAt(0);

            foreach(var line in lines)
            {
                var vals = line.Split(',');
                p = new Person();

                p.FirstName = vals[0];
                p.IsAlive = bool.Parse(vals[1]);
                p.LastName = vals[2];

                output.Add(p);
            }

            return output;
        }

        public static void SavePeople(List<Person> people, string filePath)
        {
            List<string> lines = new List<string>();

            //add a header row
            lines.Add("FirstName, IsAlive, LastName");

            foreach(var p in people)
            {
                lines.Add($"{ p.FirstName }, { p.IsAlive }, { p.LastName }");
            }

            System.IO.File.WriteAllLines(filePath, lines);
        }
    }
}
