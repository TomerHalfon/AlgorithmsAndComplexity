using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExamp
{
    class Program
    {
        static void Print(System.Collections.IEnumerable stack)
        {
            Console.Write("Stack =>");
            foreach (var item in stack)
            {
                Console.Write($" {item} ");
            }
            Console.WriteLine();
        }

        static bool ClassExc(string toValidate)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in toValidate)
            {
                //with a switch statement:
                #region Switch
                //switch (c)
                //{
                //    case '(':
                //    case '[':
                //    case '{':
                //    case '<':
                //        stack.Push(c);
                //        break;
                //    case ')':
                //        if (stack.Peek().Equals('('))
                //            stack.Pop();
                //        else return false;
                //        break;
                //    case ']':
                //        if (stack.Peek().Equals('['))
                //            stack.Pop();
                //        else return false;
                //        break;
                //    case '}':
                //        if (stack.Peek().Equals('{'))
                //            stack.Pop();
                //        else return false;
                //        break;
                //    case '>':
                //        if (stack.Peek().Equals('<'))
                //            stack.Pop();
                //        else return false;
                //        break;

                //    default:
                //        break;
                //}
                #endregion

                //with if statements:
                if (c.Equals('(') || c.Equals('[') || c.Equals('{') || c.Equals('<')) stack.Push(c);
                if (c.Equals(')'))
                {
                    if (stack.Peek().Equals('('))
                        stack.Pop();
                    else return false;
                }
                if (c.Equals(']'))
                {
                    if (stack.Peek().Equals('['))
                        stack.Pop();
                    else return false;
                }
                if (c.Equals('}'))
                {
                    if (stack.Peek().Equals('{'))
                        stack.Pop();
                    else return false;
                }
                if (c.Equals('>'))
                {
                    if (stack.Peek().Equals('<'))
                        stack.Pop();
                    else return false;
                }

            }
            return stack.Count == 0;
        }
        static void Main(string[] args)
        {
            string s = ",,   [  ( ... ) (( <> .. ) [] ) ..{ .... ((   ,,, !!! ) < [] >)} ]";

            Console.WriteLine(ClassExc(s));

            //Stack<int> stack = new Stack<int>();
            //Console.WriteLine("Pushing => 1");
            //stack.Push(1);
            //Console.WriteLine("Pushing => 2");
            //stack.Push(2);
            //Console.WriteLine("Pushing => 3");
            //stack.Push(3);
            //Console.WriteLine("Pushing => 4");
            //stack.Push(4);
            //Print(stack);
            //Console.WriteLine($"Peek => {stack.Peek()}");
            //Console.WriteLine($"Poped => {stack.Pop()}");
            //Console.WriteLine($"Peek => {stack.Peek()}");
            //Console.WriteLine($"Poped => {stack.Pop()}");
            //Console.WriteLine($"Count => {stack.Count}");
            ////Print(stack);
            //ArrayStack<int> stack = new ArrayStack<int>(4);
            //if (stack.Push(1)) Console.WriteLine("Pushed => 1");
            //else Console.WriteLine("Failed to push => 1");
            //if (stack.Push(2)) Console.WriteLine("Pushed => 2");
            //else Console.WriteLine("Failed to push => 2");
            //if (stack.Push(3)) Console.WriteLine("Pushed => 3");
            //else Console.WriteLine("Failed to push => 3");
            //if (stack.Push(4)) Console.WriteLine("Pushed => 4");
            //else Console.WriteLine("Failed to push => 4");
            //if (stack.Push(5)) Console.WriteLine("Pushed => 5");
            //else Console.WriteLine("Failed to push => 5");
            //Console.WriteLine($"Stack => {stack}");
            //if (stack.Peek(out int value)) Console.WriteLine($"Peek => {value}");
            //else Console.WriteLine("Failed to Peek");

            //while (stack.Pop(out value)) Console.WriteLine($"Poped => {value}");
            //Console.WriteLine($"failed to Pop => {value}");

            //if (stack.Peek(out value)) Console.WriteLine($"Peek => {value}");
            //else Console.WriteLine($"Failed to Peek => {value}");
            //LinkedListStack<int> stack = new LinkedListStack<int>();
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(4);
            //stack.Peek();
            //stack.Pop();
            //stack.Pop();
            //stack.Pop();
            //stack.Pop();
        }
    }
}
