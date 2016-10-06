using System;
using System.Collections.Generic;
using ConsoleWithDb;

namespace ConsoleApplication_SQL_CRUD
{

    public class Program
    {
        public static void Create()
        {
            Console.WriteLine("Creating A New User");
            Console.Write("Enter first name: ");
            string FirstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string LastName = Console.ReadLine();
            Console.Write("Enter Favorite Number: ");
            string Favorite_Number = Console.ReadLine();
            int Fav_Number = Int32.Parse(Favorite_Number); //Converting from string into integer 
            string query = $"INSERT INTO users (first_name, last_name, fav_number, created_at) VALUES('{FirstName}', '{LastName}', '{Fav_Number}', NOW())";
            DbConnector.ExecuteQuery(query);
            Console.WriteLine($"{FirstName} has been added to the db!");
        }

        public static void Read()
        {
            List<Dictionary<string, object>> myresults = DbConnector.ExecuteQuery("SELECT * FROM users");
            foreach(Dictionary<string,object> item in myresults)
            {
                Console.WriteLine(item["id"] + " " + item["first_name"] + " " +  item["last_name"] + " " + item["fav_number"] + " " + item["created_at"] + " " + item["updated_at"]);
            }
        }

        public static void Update()
        {
            Console.WriteLine("Enter ID of user you wish to update:  ");
            string userId = Console.ReadLine();
            int user_id = Int32.Parse(userId);
            Console.WriteLine("Update user's first name: ");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Update user's last name: ");
            string LastName = Console.ReadLine();
            Console.WriteLine("Update user's favorite number: ");
            string fav_num = Console.ReadLine();
            int favourite_number = Int32.Parse(fav_num);
            string query = $"UPDATE users SET first_name = '{FirstName}', last_name = '{LastName}', fav_number = '{fav_num}', updated_at = NOW() WHERE id = {user_id}";
            DbConnector.ExecuteQuery(query);
            Console.WriteLine($"{FirstName}'s info has been updated!");
        }

        public static void Destroy()
        {
            Console.WriteLine("Enter ID of user you wish to delete:  ");
            string userId = Console.ReadLine();
            int user_id = Int32.Parse(userId);
            string query = $"DELETE FROM users WHERE id = {user_id}";
            DbConnector.ExecuteQuery(query);
            Console.WriteLine($"A user has been deleted!");
        }

        public static void Main(string[] args)
        {
            // Create();
            Read();
            // Update();
            // Destroy();
            
        }
    }
}
