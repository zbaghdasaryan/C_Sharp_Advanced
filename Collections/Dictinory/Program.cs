/*
 Словарь хранит объекты, которые представляют пару ключ-значение. 
 Каждый такой объект является объектом структуры KeyValuePair<TKey, TValue>. 
 Благодаря свойствам Key и Value, которые есть у данной структуры, мы можем получить ключ и значение элемента в словаре.
 */
using System;
using System.Collections.Generic;

namespace Dictinory
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> countries = new Dictionary<int, string>(5);
            countries.Add(1, "Russia");
            countries.Add(3, "Great Britain");
            countries.Add(2, "USA");
            countries.Add(4, "France");
            countries.Add(5, "China");

            foreach (KeyValuePair<int, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }

            // получение элемента по ключу
            string country = countries[4];
            // изменение объекта
            countries[4] = "Spain";
            // удаление по ключу
            countries.Remove(2);
        }
    }
}
