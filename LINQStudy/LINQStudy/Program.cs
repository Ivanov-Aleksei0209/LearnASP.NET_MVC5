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
            Console.WriteLine("Сортировка");
            Console.WriteLine("Для сортировки набора данных в LINQ можно применять оператор orderby" +
                "");
            int[] numbers = { 3, 12, 4, 10 };
            var orderedNumbers = from i in numbers
                                 orderby i
                                 select i;
            foreach (int i in orderedNumbers)
                Console.WriteLine(i);
            string[] people = { "Tom", "Bob", "Sam" };
            var orderedPeople = from p in people orderby p select p;
            foreach (var p in orderedPeople) Console.WriteLine(p);
            Console.WriteLine("");
            Console.WriteLine("Вместо оператора orderby можно применять метод расширения OrderBy()");
            orderedNumbers = numbers.OrderBy(i => i);
            foreach (int i in orderedNumbers)
                Console.WriteLine(i);
            orderedPeople = people.OrderBy(p => p);
            foreach (var p in orderedPeople) 
                Console.WriteLine(p);
            Console.WriteLine();

            Console.WriteLine("Сортировка сложных объектов");
            var people2 = new List<Person>
            {
                new Person(37, "Tom"),
                new Person(28, "Sam"),
                new Person(22, "Tom"),
                new Person(41, "Bob")
            };
            Console.WriteLine("с помощью оператора orderby");
            var sortedPeople2 = from p in people2
                                orderby p.Name
                                select p;
            foreach (var p in sortedPeople2) 
                Console.WriteLine($"{p.Name} - {p.Age}");
            Console.WriteLine("с помощью метода OrderBy");
            sortedPeople2 = people2.OrderBy(p => p.Name);

            foreach (var p in sortedPeople2)
                Console.WriteLine($"{p.Name} - {p.Age}");
            Console.WriteLine();

            Console.WriteLine("Сортировка по возрастанию и убыванию");
            Console.WriteLine("С помощью ключевых слов ascending (сортировка по возрастанию) и " +
                "descending (сортировка по убыванию) для оператора orderby");
            orderedNumbers = from i in numbers
                             orderby i descending
                             select i;
            foreach (int i in orderedNumbers)
                Console.WriteLine(i);
            Console.WriteLine("С помощью методa OrderByDescending()");
            orderedNumbers = numbers.OrderByDescending(n => n);
            foreach (int i in orderedNumbers)
                Console.WriteLine(i);
            Console.WriteLine();

            Console.WriteLine("Множественные критерии сортировки");
            Console.WriteLine("Сортировка сложных объектов по нескольким полям");
            Console.WriteLine("с помощью оператора orderby");
            sortedPeople2 = from p in people2
                            orderby p.Name, p.Age
                            select p;
            foreach (var p in sortedPeople2)
                Console.WriteLine($"{p.Name} - {p.Age}");
            Console.WriteLine("Для разных критериев сортировки можно установить направление");
            sortedPeople2 = from p in people2
                            orderby p.Name, p.Age descending
                            select p;
            foreach (var p in sortedPeople2)
                Console.WriteLine($"{p.Name} - {p.Age}");
            Console.WriteLine("С помощью методов расширения через метод ThenBy()(для сортировки по возрастанию) и ThenByDescending() (для сортировки по убыванию)");
            sortedPeople2 = people2.OrderBy(p => p.Name).ThenByDescending(p => p.Age);
            foreach (var p in sortedPeople2)
                Console.WriteLine($"{p.Name} - {p.Age}");
            Console.WriteLine();

            Console.WriteLine("Переопределение критерия сортировки");
            Console.WriteLine("Сортировка строк изходя из их длины");
            string[] peopleMas = new[] {"Kate", "Tom", "Sam", "Mike", "Alice" };
            var sortedPeopleMas = peopleMas.OrderBy(p => p, new CustomStringComparer());

            foreach (var p in sortedPeopleMas)
                Console.WriteLine(p);

            Console.ReadKey();

        }
    }
}
