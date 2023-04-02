using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using static System.Console;
using System.Text.Json;
using System.Xml.Linq;

namespace Seryalized
{

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ID;
        const string group = "PV 221";
        public Person() { }
        public Person(int ID)
        {
            this.ID = ID;
        }
        public override string ToString()
        {
            return $"{Name} {Age} {ID} {group}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>()
            {
                new Person(1) { Name = "Olga", Age = 31 },
                new Person(2) { Name = "Anton", Age = 40 },
                new Person(3) { Name = "Elena", Age = 15 }
            };
            string fname = "List.json";

            foreach (var item in persons)
            WriteLine(item);
            string p_json = JsonSerializer.Serialize(persons);
            File.WriteAllText(fname, p_json);
            WriteLine("Serialized");

            WriteLine("********************************************");
            string p_new= File.ReadAllText(fname);
            List<Person> p_list_new = JsonSerializer.Deserialize<List<Person>>(p_new);
            foreach (var item in p_list_new)
                WriteLine(item);
            WriteLine("Deserialized");
        }
    }
}