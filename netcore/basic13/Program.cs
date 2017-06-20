using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }

            for(int i =1;i <256; i++){
                if(i%2==1){
                    Console.WriteLine(i);
                }
            }
            int sum = 0;
            for(int i = 0;i<256;i++){
                sum += i;
                Console.WriteLine("New number:"+ i + " Sum:"+ sum);
            }
            int[] numArray = {1,2,3,10,5};
            int max = 0;
            for(int idx = 0; idx<numArray.Length; idx++){
                if(numArray[idx]>max){
                    max = numArray[idx];
                }
            }
            Console.WriteLine(max);

            int[] numArray2 = {1,2,3,10,5};
            int avg = 0;
            int sum = 0;
            for(int i = 0;i<numArray2.Length; i++){
                sum += numArray2[i];
                avg = sum/numArray2.Length;
            }
            System.Console.WriteLine(avg);

            int[] oddArray = new int[256];
            for(int i = 1;i<=255;i++){
                if(i%2==1){
                    oddArray[i]=i;
                }
            }
            System.Console.WriteLine(oddArray);

            int[] numArray3 = {1,2,3,10,5};
            int count = 0;
            int greater =3;
            for(int i = 0;i<numArray3.Length; i++){
                if(numArray3[i]>greater){
                    count+=1;
                }
            }
            System.Console.WriteLine(count);

            int[] numArray4 = {9,2,2,15,5};
            for(int i = 0;i<numArray4.Length; i++){
                numArray4[i] = numArray4[i] * numArray4[i];
            }
            System.Console.WriteLine(numArray4);

            int[] numArray4 = {9,2,2,15,5};
            for(int i = 0;i<numArray4.Length; i++){
                if(numArray4<0){
                    numArray4[i]=0;
                }
            }

            int[] numArray4 = {9,2,-2,15,5};
            int max = 0;
            int min = 0;
            int avg = 0;
            int sum = 0;
            for(int i=0;i<numArray4.Length;i++){
                if(numArray4[i]>max){
                    max = numArray4[i];
                }
                if(numArray4[i]<min){
                    min = numArray4[i];
                }
                sum += numArray4[i];
            }
            avg = sum/numArray4.Length;
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine(avg);

            int[] numArray4 = {9,2,-2,15,5};
            for(int i = 0; i<=numArray4.Length; i++){
                numArray4[i] = numArray4[i+1];
            }
            numArray4[numArray4.Length-1] = 0;
            System.Console.WriteLine(numArray4);
        }
    }
}
