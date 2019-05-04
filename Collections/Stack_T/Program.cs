/*
 Класс Stack<T> представляет коллекцию, которая использует алгоритм LIFO ("последний вошел - первый вышел"). При такой организации каждый следующий добавленный элемент помещается поверх предыдущего. Извлечение из коллекции происходит в обратном порядке - извлекается тот элемент, который находится выше всех в стеке.

В классе Stack можно выделить два основных метода, которые позволяют управлять элементами:

Push: добавляет элемент в стек на первое место

Pop: извлекает и возвращает первый элемент из стека

Peek: просто возвращает первый элемент из стека без его удаления
*/

using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> numbers = new Stack<int>();

            numbers.Push(3); // в стеке 3
            numbers.Push(5); // в стеке 5, 3
            numbers.Push(8); // в стеке 8, 5, 3

            // так как вверху стека будет находиться число 8, то оно и извлекается
            int stackElement = numbers.Pop(); // в стеке 5, 3
            Console.WriteLine(stackElement);

            Stack<Person> persons = new Stack<Person>();
            persons.Push(new Person() { Name = "Tom" });
            persons.Push(new Person() { Name = "Bill" });
            persons.Push(new Person() { Name = "John" });

            foreach (Person p in persons)
            {
                Console.WriteLine(p.Name);
            }

            // Первый элемент в стеке
            Person person = persons.Pop(); // теперь в стеке Bill, Tom
            Console.WriteLine(person.Name);

            Console.ReadLine();
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
}