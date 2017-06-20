using System;
using System.Collections.Generic;
using DbConnection;


namespace ConsoleApplication
{
    public class Program
    {
        public static void Showmethe()
        {
            foreach(Dictionary<string,object> i in DbConnector.Query("Select * from Users;"))
            {
                foreach (KeyValuePair<string,object> item in i)
                {
                System.Console.WriteLine(item.Value);
                }
            }
        }
        public static void Create(){
            foreach(Dictionary<string,object> i in DbConnector.Query("INSERT INTO Users (FirstName, LastName, FavoriteNumber) Values ('{FName}', '{LName}', '{FNumber}');)";
        }

        public static void Main(string[] args)
        {
            System.Console.WriteLine("hello world");
            Showmethe();
        }
    }
}
