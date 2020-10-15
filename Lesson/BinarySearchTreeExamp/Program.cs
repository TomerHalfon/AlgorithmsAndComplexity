using BinarySearchTreeExamp.CustomBTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeExamp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            //int sampleSize = 10;
            //int LeafNum = 1000000;
            //int sum = 0;
            //for (int i = 1; i <= sampleSize; i++)
            //{
            //    tree = new BinarySearchTree<int>();
            //    for (int j = 0; j < LeafNum; j++)
            //    {
            //        tree.Insert(rnd.Next());
            //    }
            //    Console.Write($"| {i} => {tree.Depth} ");
            //    sum += tree.Depth;
            //}
            //Console.WriteLine("|");
            //Console.WriteLine($"Avg => {sum / sampleSize}");

            //tree.Traverse(TraversalOrder.InOrder, x => Console.Write($" {x} "));

            //Console.WriteLine();
            //Console.WriteLine(tree.Depth);

            tree.Insert(9);
            tree.Insert(11);
            tree.Insert(10);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(8);
            //tree.Insert(20);
            //tree.Insert(13);
            //tree.Insert(54);
            //tree.Insert(10);
            //tree.Insert(17);
            //tree.Insert(5);
            //tree.Insert(12);
            //tree.Insert(14);
            //tree.Insert(16);
            //tree.Insert(31);
            //tree.Insert(66);
            //tree.Insert(22);
            //tree.Insert(44);
            //tree.Insert(55);
            //tree.Insert(70);
            //tree.Insert(51);
            //tree.Insert(59);
            ////Console.WriteLine(tree.Delete(54));
            //tree.Traverse(TraversalOrder.InOrder, x => Console.Write($" {x} "));
        }
    }
}