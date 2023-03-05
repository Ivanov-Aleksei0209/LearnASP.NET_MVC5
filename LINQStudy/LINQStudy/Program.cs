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
            Console.WriteLine("Объединение, пересечение и разность коллекций");
            Console.WriteLine("Разность последовательностей");
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            var result = soft.Except(hard);
            foreach (string s in result)
                Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("Пересечение последовательностей");
            result = soft.Intersect(hard);

            foreach (string s in result)
                Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("Удаление дубликатов");
            string[] soft1 = { "Microsoft", "Google", "Apple", "Microsoft", "Apple"  };
            result = soft1.Distinct();

            foreach (string s in result)
                Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("Объединение последовательностей");
            result = soft.Union(hard);

            foreach (string s in result)
                Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("Простое объединение последовательностей");
            result = soft.Concat(hard);

            foreach (string s in result)
                Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("Работа со сложными объектами");
            Person[] students = { new Person("Tom"), new Person("Bob"), new Person("Sam") };
            Person[] employees = { new Person("Tom"), new Person("Bob"), new Person("Mike") };
            
            Console.WriteLine("Oбъединение последовательностей");
            var people = students.Union(employees);

            foreach (Person person in people)
                Console.WriteLine(person.Name);
            Console.ReadKey();



        }
    }
}
