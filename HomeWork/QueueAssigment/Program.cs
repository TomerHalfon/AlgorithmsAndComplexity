using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAssigment
{
    class Program
    {
        static int GetNum(string msg)
        {
            int num;
            Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid input!\nTry again...");
            }
            return num;
        }
        static void Print(IEnumerable<int> queue)
        {
            Console.WriteLine("The Queue =>");
            foreach (int item in queue)
            {
                Console.Write($" {item} ");
            }
            Console.WriteLine();
        }
        static void TestQueue(ArrayQueue<int> queue)
        {
            for (int i = 0; i < queue.Capacity; i++)
            {
                Console.WriteLine($"EnQueue => {queue.EnQueue(GetNum("Add Number to queue => "))}");
                Print(queue);
            }
            int deQueueIterations = GetNum("How many to DeQueue => ");
            for (int j = 0; j < deQueueIterations; j++)
            {
                Console.WriteLine($"\nDeQueued => {queue.DeQueue(out int deQueued)} => {deQueued}");
                Print(queue);
            }
            int enQueueIterations = GetNum("How many to EnQueue => ");
            for (int j = 0; j < enQueueIterations; j++)
            {
                Console.WriteLine($"EnQueue => {queue.EnQueue(GetNum("Add Number to queue => "))}");
                Print(queue);
            }
        }
        static void Main(string[] args)
        {
            ArrayQueue<int> queue = new ArrayQueue<int>(GetNum("Enter Queue Capacity => "));
            Console.WriteLine();
            TestQueue(queue);
        }
    }
}