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
            Console.WriteLine("Проверка наличия и получение элементов");
            Console.WriteLine();

            string[] people = { "Tom", "Tim", "Bob", "Sam" };
            foreach (string person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();
            Console.WriteLine("Метод All()");
            Console.WriteLine("проверяем, все ли элементы имеют длину в 3 символа");
            bool allHas3Chars = people.All(s => s.Length == 3);
            Console.WriteLine(allHas3Chars);
            Console.WriteLine("проверяем, все ли строки начинаются на T");
            bool allStartsWithT = people.All(s => s.StartsWith("T"));
            Console.WriteLine(allStartsWithT);
            Console.WriteLine();

            Console.WriteLine("Метод Any()");
            Console.WriteLine("проверяем, есть ли элементы, которые имеют длину больше 3 символов");
            bool allHasMore3Chars = people.Any(s => s.Length > 3);
            Console.WriteLine(allHasMore3Chars);
            Console.WriteLine("проверяем, есть ли строки, которые начинаются на T");
            bool anyStartsWithT = people.Any(s => s.StartsWith("T"));
            Console.WriteLine(anyStartsWithT);
            Console.WriteLine();
            
            Console.WriteLine("Метод Contains()");
            Console.WriteLine("проверяем, есть ли строка Tom");
            bool hasTom = people.Contains("Tom");
            Console.WriteLine(hasTom);
            Console.WriteLine("проверяем, есть ли строка Mike");
            bool hasMike = people.Contains("Mike");
            Console.WriteLine(hasMike);

            Console.WriteLine();
            Console.WriteLine("для сравнения объектов применяется реализация метода Equals");
            
            Person[] people1 = { new Person("Tom"), new Person("Sam"), new Person("Bob") };
            
            var tom = new Person("Tom");
            var mike = new Person("Mike");
            Console.WriteLine("проверяем, есть ли строка Tom");
            hasTom = people1.Contains(tom);
            Console.WriteLine(hasTom);
            Console.WriteLine("проверяем, есть ли строка Mike");
            hasMike = people1.Contains(mike);
            Console.WriteLine(hasMike);


            Console.ReadKey();
        }
    }
}
