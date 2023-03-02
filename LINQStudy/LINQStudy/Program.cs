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
            string[] people = { "Tom ", "Bob ", "Sam ", "Tim ", "Tomas ", "Bill ", "Serg " };
            foreach (string person in people)
                Console.Write(person);
            Console.WriteLine("");
            Console.WriteLine("========================");
            Console.WriteLine("Простой способ");
            // создаем новый список для результатов
            var selectedPeopleT = new List<string>();
            // проходим по массиву
            foreach (string person in people)
            {
                // если строка начинается на букву Т, добавляем в список
                if (person.ToUpper().StartsWith("T"))
                    selectedPeopleT.Add(person);
            }
            // сортируем список
            selectedPeopleT.Sort();

            foreach (string person in selectedPeopleT)
                Console.WriteLine(person);
            Console.ReadLine();

            // Операторы запросов LINQ
            Console.WriteLine("Операторы запросов LINQ");
            // создаем новый список для результатов
            var selectedPeopleLinqB = from p in people // передаем каждый элемент из people в переменную p
                                     where p.ToUpper().StartsWith("B") // фильтрация по критерию
                                     orderby p // упорядочиваем по возрастанию
                                     select p; // выбираем объект в создаваемую коллекцию
            foreach (string personLinq in selectedPeopleLinqB)
                Console.WriteLine(personLinq);
            Console.ReadLine();

            // Методы расширения LINQ
            Console.WriteLine("Методы расширения LINQ");

            var selectedPeopleS = people.Where(p => p.ToUpper().StartsWith("S")).OrderBy(p => p);

            foreach (string person in selectedPeopleS)
                Console.WriteLine(person);
            Console.ReadLine();
        }
    }
}
