using System;
using System.CodeDom.Compiler;
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
            Console.WriteLine("Соединение коллекций");
            Console.WriteLine();
            Console.WriteLine("Оператор join");
            Console.WriteLine();
            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
            };

            Company[] companies =
            {
                new Company("Microsoft", "C#"),
                new Company("Google", "Go"),
                new Company("Oracle", "Java")
            };

            var employees = from p in people
                            join c in companies on p.Company equals c.Title
                            select new { Name = p.Name, Company = c.Title, Language = c.Language };

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Name} - {emp.Company} ({emp.Language})");
            }
           
            Console.WriteLine();
            Console.WriteLine("Метод Join()");
            Console.WriteLine();

            var employees2 = people.Join(companies, // второй набор
                         p => p.Company,            // свойство-селектор объекта из первого набора
                         c => c.Title,              // свойство-селектор объекта из второго набора
                         (p, c) => new { Name = p.Name, Company = c.Title, Language = c.Language}); // результат

            foreach (var emp in employees2)
                Console.WriteLine($"{emp.Name} - {emp.Company} ({emp.Language})");
            Console.WriteLine();
            Console.WriteLine("Метод GroupJoin()");
            Console.WriteLine();
            var personnel = companies.GroupJoin(people,
                c => c.Title,
                p => p.Company,
                (c, employees3) => new
                {
                    Title = c.Title,
                    Employees3 = employees3
                });
            foreach (var company in personnel)
            {
                Console.WriteLine(company.Title);
                foreach (var emp in company.Employees3)
                {
                    Console.WriteLine(emp.Name);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Метод Zip()");
            Console.WriteLine();

            var courses = new List<Course> { new Course("C#"), new Course("Java") };
            var students = new List<Student> { new Student("Tom"), new Student("Bob") };

            //var enrollments = courses.Zip(students);

            //foreach (var enrollment in enrollments)
            //    Console.WriteLine($"{enrollment.First} - {enrollment.Second}");

            Console.ReadKey();
        }
    }
}
