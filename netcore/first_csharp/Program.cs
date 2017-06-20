using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Using Console.WriteLine, you can output any string to the terminal/console");
            for (int i = 1; i<=255; i++)
            {
                Console.WriteLine(i);
            }
            for (int x = 1;x<=100; x++)
            {
                if (x%3 == 0 && x%5!=0)
                {
                    Console.WriteLine(x);
                }
                if (x%5==0 && x%3!=0){
                    Console.WriteLine(x);
                }
            }
            for (int x = 1;x<=100; x++)
            {
                if (x%3 == 0 && x%5!=0)
                {
                    Console.WriteLine("fizz");
                }
                if (x%5==0 && x%3!=0)
                {
                    Console.WriteLine("buzz");
                }
                if (x%3 == 0 && x%5==0)
                {
                    Console.WriteLine("FizzBuzz");
                }
            }
        }
    }
}
