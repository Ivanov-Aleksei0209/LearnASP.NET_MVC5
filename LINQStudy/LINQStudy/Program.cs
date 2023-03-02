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
            Console.WriteLine("Проекция данных");
            var people = new List<Person>()
            {
                new Person (23, "Tom"),
                new Person (27, "Bob"),
                new Person (29, "Sam"),
                new Person (24, "Alice")
            };
            foreach (var person in people)
                Console.WriteLine($"{person.Name}, {person.Age}");
            Console.WriteLine();
            Console.WriteLine("Делаем выборку только значения свойства Name");
            var names = from p in people select p.Name;
            foreach (string n in names)
                Console.WriteLine(n);
            //Console.ReadLine();

            Console.WriteLine("Проекция данных - метод расширения Select()");

            var namesSelect = people.Select(p => p.Name);

            foreach (string n in namesSelect)
                Console.WriteLine(n);
            //Console.ReadLine();

            Console.WriteLine("Создание объектов другого типа");
            var personel = from p in people
                           select new
                           {
                               FirstName = p.Name,
                               Year = DateTime.Now.Year - p.Age
                           };
            foreach (var p in personel)
                Console.WriteLine($"{p.FirstName} - {p.Year}");
            //Console.ReadLine();
            Console.WriteLine("Создание объектов другого типа через лямбда-функцию");
            var personelLambda = people.Select(p => new
            {
                FirstName = p.Name,
                Year = DateTime.Now.Year - p.Age
            });
            foreach (var p in personel)
                Console.WriteLine($"{p.FirstName} - {p.Year}");
            //Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Переменые в запросах и оператор let");
            var personnel = from p in people
                            let name = $"Mr. {p.Name}"
                            let year = DateTime.Now.Year - p.Age
                            select new
                            {
                                Name = name,
                                Year = year
                            };
            foreach (var p in personnel) Console.WriteLine($"{p.Name} - {p.Year}");
            //Console.ReadLine();
            Console.WriteLine();


            Console.WriteLine("Выборка из нескольких источников");
            var courses = new List<Course> { new Course("C#"), new Course("Java") };
            var students = new List<Student> { new Student("Tom"), new Student("Bob") };

            var enrollments = from course in courses // выбираем по одному курсу
                              from student in students // выбираем по одному студенту
                              select new { Student = student.Name, Course = course.Title }; // соединяем каждого студента с каждым курсом


            foreach (var enrollment in enrollments)
                Console.WriteLine($"{enrollment.Student} - {enrollment.Course}");
            //Console.ReadLine();
            Console.WriteLine();


            Console.WriteLine("SelectMany и сведение объектов");
            var companies = new List<Company>()
            {
            new Company("Microsoft", new List<Person> {new Person("Tom"), new Person("Bob")}),
            new Company("Google" , new List<Person> {new Person("Sam"), new Person("Mike")})
            };
            
            var employees = companies.SelectMany(c => c.Staff);

            foreach (var emp in employees)
                Console.WriteLine($"{emp.Name}");
            Console.ReadKey();
            Console.WriteLine("Аналогичный пример с помощью операторов LINQ");
            var employees1 = from c in companies
                            from emp in c.Staff
                            select emp;

            foreach (var emp in employees1)
                Console.WriteLine($"{emp.Name}");
            Console.ReadKey();

            Console.WriteLine("Аналогичный пример с помощью операторов LINQ");

            var employees2 = companies.SelectMany(c => c.Staff,
                (c, emp) => new { Name = emp.Name, Company = c.Name });
            foreach (var emp in employees2)
                Console.WriteLine($"{emp.Name} - {emp.Company}");
            Console.ReadKey();

            Console.WriteLine("Аналогичный пример с помощью операторов запросов");
            var employees3 = from c in companies
                             from emp in c.Staff
                             select new { Name = emp.Name, Company = c.Name };

            foreach (var emp in employees3)
                Console.WriteLine($"{emp.Name} - {emp.Company}");
            Console.ReadKey();
            
        }
    }
}
