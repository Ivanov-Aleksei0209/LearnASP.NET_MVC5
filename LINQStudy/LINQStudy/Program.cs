using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQStudy
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Группировка");
            Console.WriteLine();
            Console.WriteLine("Оператор group by");
            Console.WriteLine();
            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
                new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft")
            };

            var companies = from person in people
                            group person by person.Company;

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);
                foreach (var person in company)
                {
                    Console.WriteLine(person.Name);
                }
                Console.WriteLine();
            }
            Console.WriteLine("GroupBy");
            Console.WriteLine();

            companies = people.GroupBy(p => p.Company);
            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);

                foreach (var person in company)
                {
                    Console.WriteLine(person.Name);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Создание нового объекта при группировке");
            Console.WriteLine();

            var companies1 = from person in people
                        group person by person.Company into g
                        select new {Name = g.Key, Count = g.Count()}; 
            foreach (var company in companies1)
            {
                Console.WriteLine($"{company.Name} : {company.Count}");
            }
            Console.WriteLine();
            Console.WriteLine("Создание нового объекта с помощью метода GroupBy()");
            Console.WriteLine();

            var companies2 = people.GroupBy(p => p.Company)
                .Select(g => new {Name = g.Key, Count = g.Count()});

            foreach (var company in companies2)
            {
                Console.WriteLine($"{company.Name} : {company.Count}");
            }
            Console.WriteLine();
            
            Console.WriteLine("Вложенные запросы");
            Console.WriteLine();
            Console.WriteLine("Создание нового объекта при группировке");
            Console.WriteLine();
            var companies3 = from person in people
                             group person by person.Company into g
                             select new
                             {
                                 Name = g.Key,
                                 Count = g.Count(),
                                 Employees = from p in g select p
                             };
            foreach (var company in companies3)
            {
                Console.WriteLine($"{company.Name} : {company.Count}");
                foreach (var employee in company.Employees)
                {
                    Console.WriteLine(employee.Name);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Создание нового объекта с помощью метода GroupBy()");
            Console.WriteLine();
            var companies4 = people
                .GroupBy(p => p.Company)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count(),
                    Employees = g.Select(p => p)
                });
            foreach (var company in companies4)
            {
                Console.WriteLine($"{company.Name} : {company.Count}");
                foreach (var employee in company.Employees)
                {
                    Console.WriteLine(employee.Name);
                }
                Console.WriteLine();
            }
            Console.ReadKey();



        }
    }
}
