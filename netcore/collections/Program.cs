using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            int[] array;
            array = new int[] {0,1,2,3,4,5,6,7,8,9};
            string[] names = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
            bool[] truefalse = new bool[10] {true, false, true, false, true, false, true, false, true, false};
            int [,] multitable = new int[10,10];
            for (int i = 0; i < 10; i++)
            {
                for (int x = 0; x < 10; x++)
                {
                    multitable[i,x] = (i + 1) * (x + 1);
                }
            }
            for(int i = 0; i<10;i++)
            {
                string display = NewMethod();
                for (int x = 0; x < 10; x++)
                {
                    display += multitable[i, x] + ",";
                    if (multitable[i, x] < 10)
                    {
                        display += " ";
                    }
                }

                display += "]";
                Console.WriteLine(display);
            }
            List<string> icecreams = new List<string>();
            icecreams.Add("Vanilla");
            icecreams.Add("Chocolate");
            icecreams.Add("Cookies and cream");
            icecreams.Add("Mint chocolate chip");
            icecreams.Add("Coffee");
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine(icecreams.Count);
            System.Console.WriteLine(icecreams[2]);
            icecreams.Remove("Cookies and cream");
            System.Console.WriteLine(icecreams.Count);

            Dictionary<string,string> nameIC = new Dictionary<string,string>();
            Random rand = new Random();
            foreach(string name in names)
            {
                nameIC[name] = icecreams[rand.Next(icecreams.Count)];
            }
            foreach(KeyValuePair<string,string> info in nameIC){
                System.Console.WriteLine(info.Key + "-" + info.Value);
            }

        }

        private static string NewMethod()
        {
            return "[";
        }
    }
}
