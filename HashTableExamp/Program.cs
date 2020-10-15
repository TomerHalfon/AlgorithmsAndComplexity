using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableExamp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random rnd = new Random();
            //int size = 10;
            //HashTable<int, string> h = new HashTable<int, string>(size);
            //for (int i = 1; i <= size; i++)
            //{
            //    //int n = rnd.Next();
            //    h.Add(i, i.ToString());
            //}
            //foreach (var item in h)
            //{
            //    Console.Write($" {item.Value} ");
            //}
            //Console.WriteLine();
            ////Console.WriteLine($"{h.Get(1, out string s)} => {s}");
            ////Console.WriteLine($"{h.Get(2, out s)} => {s}");
            ////h[1] = "hello";
            //h.Add(11, 11.ToString());
            ////Console.WriteLine($"\n{h.Get(11, out string s)} => {s}\n");
            //foreach (var item in h)
            //{
            //    Console.Write($" {item.Value} ");
            //}
            //Console.WriteLine();
            //Console.WriteLine();

            HashTableDoubleHashing<int, string> h = new HashTableDoubleHashing<int, string>(3);
            h.Add(1, "a");
            h.Add(2, "b");
            h.Add(3, "c");
            h.Add(4, "d");
            h.Add(5, "e");
            h.Add(6, "f");
            h.Add(20, "f");
            h.Add(20, "f");
        }
    }
    class Person
    {
        static int IDCounter = 1;

        public Person(string name, DateTime dateOfBirth)
        {
            Id = IDCounter++;
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Id == person.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
