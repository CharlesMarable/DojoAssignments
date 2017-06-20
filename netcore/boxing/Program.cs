using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<object> boxing = new List<object>();
            boxing.Add(7);
            boxing.Add(28);
            boxing.Add(-1);
            boxing.Add(true);
            boxing.Add("chair");
            int sum = 0;
            foreach(var obj in boxing){
                System.Console.WriteLine(obj);
                if(obj is int){
                    sum += (int)obj;
                }
            }
            System.Console.WriteLine("The sum of the ints in boxing is {0}", sum);
        }
    }
}
