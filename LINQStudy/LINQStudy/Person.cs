using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQStudy
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public List<string> Languages { get; set; }

        public Person() { }
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
        public Person(string name)
        {
            Name = name;
        }
        public Person(string name, int age, List<string> languages)
        {
            Name = name;
            Age = age;
            Languages = languages;
        }
        public override bool Equals(object obj)
        {
            if (obj is Person person)
            return Name == person.Name;
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
