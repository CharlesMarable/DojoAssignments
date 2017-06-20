using System;

namespace ConsoleApplication
{
    public class Program
    {
        public int[] RandomArray(){
            Random rand = new Random();
            int[] randArray = new int[10];
            int sum = 0;
            int max = 0;
            int min = 26;
            for(int idx = 0; idx < randArray.Length;idx++){
                int val = rand.Next(5,26);
                if(val < min){
                    min = val;
                }
                if(val > max){
                    max = val;
                }
                randArray[idx]= val;
                
                sum += val;
            }
            System.Console.WriteLine("The sum of the array is {0}", sum);
            System.Console.WriteLine("The max is: {0} and the min is: {1}", max, min);
            return randArray;

        }

        public string CoinFlip(){
            System.Console.WriteLine("Tossing a Coin!");
            
        }
            
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RandomArray();

        }
    }
}
