using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQStudy
{
    internal class Company
    {
        public string Name { get; set; }
        public List<Person> Staff { get; set; }

        public Company(string name, List<Person> staff)
        {
            Name = name;
            Staff = staff;
        }
    }
}
