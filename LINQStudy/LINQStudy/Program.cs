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
            Console.WriteLine("Агрегатные операции");
            Console.WriteLine("Метод Aggregate");
            int[] numbers = { 1, 2, 3, 4, 5 };

            int query = numbers.Aggregate((x, y) => x - y);

                Console.WriteLine(query);

            query = numbers.Aggregate((x, y) => x + y);
            Console.WriteLine(query);

            string[] words = { "Gaudeamus", "igitur", "Juvenes", "dum", "sumus" };
            var sentence = words.Aggregate("Text:", (first, next) => $"{first} {next}");
            Console.WriteLine(sentence);

            Console.WriteLine();
            Console.WriteLine("Получение размера выборки. Метод Count");
            int[] numbers2 = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
            int size = numbers2.Count();
            Console.WriteLine(size);
            Console.WriteLine("количество четных чисел, которые больше 10");
            size = numbers2.Count(i => i % 2 == 0 && i > 10);
            Console.WriteLine(size);

            Console.WriteLine();
            Console.WriteLine("Получение суммы");
            int sum = numbers2.Sum();
            Console.WriteLine(sum);
            Console.WriteLine("Получение суммы в сложных объектах");
            Person[] people = { new Person(37, "Tom"), new Person(28, "Sam"), new Person(41, "Bob") };
            int ageSum = people.Sum(p => p.Age);
            Console.WriteLine(ageSum);

            Console.WriteLine();
            Console.WriteLine("Максимальное, минимальное и среднее значения");
            
            int max = numbers2.Max();
            int min = numbers2.Min();
            double average = numbers2.Average();
            
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Average: {average}");
            
            Console.WriteLine("Максимальное, минимальное и среднее значения в сложных объектах");
            
            int minAge = people.Min(p => p.Age);
            int maxAge = people.Max(p => p.Age);
            double averageAge = people.Average(p => p.Age);
            
            Console.WriteLine($"Min: {minAge}");
            Console.WriteLine($"Max: {maxAge}");
            Console.WriteLine($"Average: {averageAge}");
            Console.ReadKey();



        }
    }
}
