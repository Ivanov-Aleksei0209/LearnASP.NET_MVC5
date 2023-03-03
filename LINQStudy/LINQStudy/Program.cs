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
            Console.WriteLine("Применение метода Where для фильтрации списка");
            Console.WriteLine("выберем все строки, длина которых равна 3");
            string[] people1 = { "Tom", "Alice", "Bob", "Sam", "Tim", "Tomas", "Bill" };
            var selectedPeople1 = people1.Where(p => p.Length == 3);
            foreach (string person in selectedPeople1)
                Console.WriteLine(person);
            //Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Аналогичный запрос с помощью операторов LINQ");
            Console.WriteLine("выберем все строки, длина которых равна 4");
            var selectedPeopleLinq1 = from p in people1
                                     where p.Length == 4
                                     select p;
            foreach (string person in selectedPeopleLinq1)
                Console.WriteLine(person);
            //Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Фильтрация с помощью операторов LINQ");
            Console.WriteLine("выберем все четные элементы, которые больше 10");
            int[] numbers = { 1, 2, 3, 4, 10, 34, 5, 55, 66, 77, 8, 88 };
            // метод расширения
            Console.WriteLine("метод расширения");
            var evens1 = numbers.Where(i => i % 2 == 0 && i > 10);
            foreach (int n in evens1)
                Console.WriteLine(n);
            Console.WriteLine("");
            Console.WriteLine("операторы запросов");
            // операторы запросов
            var evens2 = from i in numbers
                         where i % 2 == 0 && i > 10
                         select i;
            foreach (int p in evens2)
                Console.WriteLine(p);
            //Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("************************************************");
            Console.WriteLine("Выборка сложных объектов");
            var people2 = new List<Person>
            {
                new Person ("Tom", 23, new List<string> {"english", "german"}),
                new Person ("Bob", 27, new List<string> {"english", "french"}),
                new Person ("Sam", 29, new List<string> {"english", "spanish"}),
                new Person ("Alice", 24, new List<string> {"spanish", "german"})
            };
            Console.WriteLine("выберем из тех, которым больше 25 лет");
            var selectedPeopleLinq2 = from p in people2
                                  where p.Age > 25
                                  select p;
            foreach (Person person in selectedPeopleLinq2)
                Console.WriteLine($"{person.Name} - {person.Age}");
            //Console.ReadKey();

            Console.WriteLine("Аналогичный запрос с помощью метода расширения Where");
            var selectedPeople2 = people2.Where(p => p.Age > 25);
            foreach (Person person in selectedPeople2)
                Console.WriteLine($"{person.Name} - {person.Age}");
            //Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("************************************************");
            Console.WriteLine("Сложные фильтры");
            Console.WriteLine("надо отфильтровать пользователей по языку english");
            var selectedPeopleLinq3 = from person in people2
                                      from lang in person.Languages
                                      where person.Age < 28
                                      where lang == "english"
                                      select person;
            foreach (Person person in selectedPeopleLinq3)
                Console.WriteLine($"{person.Name} - {person.Age}");
            //Console.ReadKey();
            Console.WriteLine("Для создания аналогичного запроса с помощью методов расширения применяется метод SelectMany");
            var selectedPeopleSelectMany = people2.SelectMany(u => u.Languages,
                (u, l) => new { Person = u, Lang = l })
                .Where(u => u.Lang == "english" && u.Person.Age < 28)
                .Select(u => u.Person);
            foreach (Person person in selectedPeopleSelectMany)
                Console.WriteLine($"{person.Name} - {person.Age}");
            //Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("************************************************");
            Console.WriteLine("Фильтрация по типу данных");

            var people3 = new List<Person>
            {
                new Student("Tom"),
                new Person("Sam"),
                new Student("Bob"),
                new Employee("Mike")
            };
            var students = people3.OfType<Student>();

            foreach (var student in students) 
                Console.WriteLine(student.Name);
            Console.ReadKey();
        }
    }
}
