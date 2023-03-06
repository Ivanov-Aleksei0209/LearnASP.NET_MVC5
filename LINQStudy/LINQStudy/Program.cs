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
            Console.WriteLine("Методы Skip и Take");
            Console.WriteLine("Метод Skip");
            string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob", "Alice" };
            Console.WriteLine("пропускаем первые два элемента");
            var result = people.Skip(2);

            foreach (var item in result) 
                Console.WriteLine(item);
            Console.WriteLine("SkipLast(2) пропускаем последние два элемента");

            //var result2 = people.SkipLast(2);

            //foreach (var item in result)
            //    Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine("SkipWhile() пропускает цепочку элементов, начиная с первого элемента, пока они удовлетворяют определенному условию");

            Console.WriteLine("пропускаем первые элементы, длина которых равна 3");
            result = people.SkipWhile(p => p.Length == 3);

            foreach (var item in result) Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("Take() извлекает определенное число элементов");

            Console.WriteLine("извлекаем первые 3 элемента");
            result = people.Take(3);

            foreach (var item in result) Console.WriteLine(item);
            //Console.WriteLine();
            //Console.WriteLine("TakeLast() извлекает определенное число элементов с конца");

            //Console.WriteLine("извлекаем последние 3 элемента");
            //result = people.TakeLast(3);
            //foreach (var item in result) Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("TakeWhile() извлекает цепочку элементов, начиная с первого элемента, пока они удовлетворяют определенному условию");

            Console.WriteLine("извлекаем первые элементы, длина которых равна 3");
            result = people.TakeWhile(p => p.Length == 3);

            foreach (var item in result) Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine("Постраничный вывод");

            Console.WriteLine("пропускаем 3 элемента и выбираем 2 элемента");
            result = people.Skip(3).Take(2);

            foreach (var item in result) Console.WriteLine(item);

            Console.ReadKey();



        }
    }
}
