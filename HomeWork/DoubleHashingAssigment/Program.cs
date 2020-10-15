using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleHashingAssigment
{
    class Program
    {
        static void Main(string[] args)
        {
            TestLoop();               /*The Dynamic Tests Loop*/

            //RunStaticTests();         /*The Static Tests*/
        }
        static void TestLoop()
        {
            Hash_DoubleHashing<int, string> h = new Hash_DoubleHashing<int, string>(GetNum("capacity => "));
            Console.WriteLine("Created a hash table\n");
            //just a loop the test with
            while (true)
            {
                Print(h);
                Console.WriteLine(GetActionsDisplay());
                switch (GetAction())
                {
                    case Actions.Add:
                        TestAdd(h);
                        break;
                    case Actions.Delete:
                        TestDelete(h);
                        break;
                    case Actions.Get:
                        TestGet(h);
                        break;
                    case Actions.Set:
                        TestSet(h);
                        break;
                    case Actions.Clear:
                        Console.Clear();
                        break;
                    case Actions.Exit:
                        return;
                }
            }
        }
        enum Actions
        {
            Add = 1,
            Delete,
            Get,
            Set,
            Clear,
            Exit
        }

        #region User Input Methods
        static Actions GetAction()
        {
            int input = GetNum($"insert num of action => ");
            while (true)
            {
                Actions action = (Actions)input;
                switch (action)
                {
                    case Actions.Add:
                    case Actions.Delete:
                    case Actions.Get:
                    case Actions.Set:
                    case Actions.Clear:
                    case Actions.Exit:
                        return action;
                    default:
                        Console.WriteLine("Invalid input!\nTry again...");
                        input = GetNum($"insert num of action => ");
                        break;
                }
            }
        }
        static string GetActionsDisplay()
        {
            string[] actions = Enum.GetNames(typeof(Actions));
            StringBuilder sb = new StringBuilder("Actions:\n");

            for (int i = 1; i <= actions.Length; i++)
            {
                sb.AppendLine($"{i}. {actions[i - 1]}");
            }
            return sb.ToString();
        }
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
        static string GetWord(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        } 
        #endregion

        //Tests
        #region PreMade dynamic Tests With UserInput
        static void TestAdd(Hash_DoubleHashing<int, string> h)
        {
            int addAmount = GetNum("\nHow many to add => ");
            Console.WriteLine();
            for (int i = 0; i < addAmount; i++)
            {
                try
                {
                    h.Add(GetNum("Key => "), GetWord("Value => "));
                    Console.WriteLine($"Added\n");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"FAILED => {e.Message}\n");
                    i--;
                }
            }
        }
        static void TestDelete(Hash_DoubleHashing<int, string> h)
        {
            if (h.Count < 1)
            {
                Console.WriteLine("Empty Table!");
                return;
            }
            int deleteAmount = GetNum("How many to delete => ");
            Console.WriteLine();
            for (int i = 0; i < deleteAmount; i++)
            {
                int key = GetNum("Key to delete => ");
                if (h.Delete(key, out string deletedValue))
                {
                    Console.WriteLine($"Key => {key} was deleted deleted value => {deletedValue}");
                }
                else
                {
                    Console.WriteLine($"Key not found => {key}");
                    i--;
                }
                Console.WriteLine();
            }
        }
        static void TestGet(Hash_DoubleHashing<int, string> h)
        {
            if (h.Count < 1)
            {
                Console.WriteLine("Empty Table!");
                return;
            }
            int searchAmount = GetNum("How many to search => ");
            Console.WriteLine();
            for (int i = 0; i < searchAmount; i++)
            {
                try
                {
                    int key = GetNum("Key to search => ");
                    Console.WriteLine($"value => {h[key]}");
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine($"FAILED => {e.Message}\n");
                    i--;
                }
            }
        }
        static void TestSet(Hash_DoubleHashing<int, string> h)
        {
            if (h.Count < 1)
            {
                Console.WriteLine("Empty Table!");
                return;
            }
            int modifyAmount = GetNum("How many to modify => ");
            Console.WriteLine();
            for (int i = 0; i < modifyAmount; i++)
            {
                try
                {
                    int key = GetNum("Key to modify => ");
                    string newValue = GetWord("New value => ");
                    h[key] = newValue;
                    Console.WriteLine($"Changed key => {key} to new value => {newValue}");
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine($"FAILED => {e.Message}\n");
                    i--;
                }
            }
        }
        static void Print (Hash_DoubleHashing<int, string> h)
        {
            Console.WriteLine("============ the hash table ============");
            foreach (var item in h)
            {
                Console.WriteLine($"Key => {item.Key} Value => {item.Value}");
            }
            Console.WriteLine("========================================");

        }
        #endregion
        #region PreMade Static Tests
        static void RunStaticTests()
        {
            Console.Write("Test 1 => ");
            Test1();
            Console.WriteLine(); Console.Write("Test 2 => ");
            Test2();
            Console.WriteLine();
        }
        static void Test1()
        {
            Hash_DoubleHashing<int, string> h = new Hash_DoubleHashing<int, string>(4); //should be size 5
            h.Add(1, "1");
            h.Add(6, "6"); //should step over 1
            h.Delete(1, out string _);
            try
            {
                h.Add(6, "6"); //should fail
            }
            catch (Exception)
            {
                Console.WriteLine("Test Successful!");
                return;
            }
            Console.WriteLine("Test Failed!");
        }
        static void Test2()
        {
            Hash_DoubleHashing<int, string> h = new Hash_DoubleHashing<int, string>(3) //should be size 5
            {
                { 1, "1" },
                { 6, "6" }
            };
            h.Delete(1, out string _);
            h.Add(1, "1"); 
        }
        #endregion
    }
}