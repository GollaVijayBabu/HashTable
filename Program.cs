using System;
namespace HashTable 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hash table program");
            Console.WriteLine("Welcome to hash table program \n");
            Console.WriteLine("Please select following options \n");
            Console.WriteLine(" 1.UC_1 \n 2.UC_2 \n 3.UC_3 \n");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    MyMapNode<string, string> hashTale = new MyMapNode<string, string>(5);

                    hashTale.Add("0", "To");
                    hashTale.Add("1", "be");
                    hashTale.Add("2", "or");
                    hashTale.Add("3", "not");
                    hashTale.Add("4", "to");
                    hashTale.Add("5", "be");

                    string hash5 = hashTale.Get("5");
                    Console.WriteLine("5th index value is {0}", hash5);

                    string hash2 = hashTale.Get("2");
                    Console.WriteLine("2nd index value is {0}", hash2);

                    break;

                case 2:
                    string paragraph = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
                    string[] para = paragraph.Split(" ");

                    MyMapNode<int, string> hash = new MyMapNode<int, string>(para.Length);
                    int key = 0;
                    foreach (string word in para)
                    {
                        hash.Add(key, word);
                        key++;
                    }
                    Operation operation = new Operation();
                    operation.Frequency(hash);
                    break;

                case 3:
                    string paragraph1 = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
                    string[] para1 = paragraph1.Split(" ");

                    MyMapNode<int, string> hash1 = new MyMapNode<int, string>(para1.Length);
                    int key1 = 0;
                    foreach (string word in para1)
                    {
                        hash1.Add(key1, word);
                        key1++;
                    }
                    Operation operation1 = new Operation();
                    operation1.Remove(hash1, "avoidable");
                    break;

                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }
}