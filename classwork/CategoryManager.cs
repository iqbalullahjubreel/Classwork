using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class CategoryManager : ProductManager
    {
    private static List<Category> categories = new List<Category>();

    private static string ConnectionStringWithoutDB = "server=localhost;User=root;password=oladapo";
    private static string ConnectionString = "server=localhost;User=root;database=CategoryDataBase;password=oladapo";
    public static void CreateCategoryDB()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionStringWithoutDB))
        {
            connection.Open();
            string query = "Create Database if not exists CategoryDataBase";

            MySqlCommand command = new MySqlCommand(query, connection);
            var execute =
            command.ExecuteNonQuery();

            if (execute > 0)
            {
                Console.WriteLine("Database Created Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Create Database.");
            }
        }
    }
    public static void CreateCategoryTable()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "create table if not exists CategoryDataBase.categories(id int primary Key not null auto_increment, Name varchar(225) Not Null, categoryid int primary key not null);";

            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery();

            if (execute == 0)
            {
                Console.WriteLine("Table Created Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Create Table.");
            }
        }
    }
    public static void CreateCategory(Category category1)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Product product1 = new Product();

            Console.WriteLine("Enter the Category");
            string category = Console.ReadLine();
            Console.WriteLine("Enter the categoryId");
            int newquantity = int.Parse(Console.ReadLine());
            category1.CategoryName = category;
            category1.CategoryID = newquantity;
            MySqlCommand insert = new MySqlCommand($"insert into categories(Name, categoryid) values('{category1.CategoryName}','{category1.CategoryID}');", connection);

            var execute = insert.ExecuteNonQuery();

            if (execute == 0)
            {
                Console.WriteLine("Category Created Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Create Category.");
            }

        }
    }

    public static void DeleteCategory()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Console.WriteLine("Enter the id of the Category you want to delete");
            int id = int.Parse(Console.ReadLine());
            string query = $"DELETE from CategoryDataBase.categories  where id = {id};";
            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery();
            if (execute > 0)
            {
                Console.WriteLine("deleted Sucessfully");
            }
            else
            {
                Console.WriteLine("Unable to update");
            }
        }
    }
    public static void GetAllCategories()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string selectquery = "SELECT id, Name, categoryid FROM CategoryDataBase.categories";
            using (MySqlCommand command = new MySqlCommand(selectquery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name {reader["Name"]}, categoryid: {reader["categoryid"]},\n ");
                    }
                }
            }
        }
    }
    public static Product GetCategory(int id)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string selectquery = $"SELECT id, Name, categoryid FROM categories WHERE id = {id}";

            using (MySqlCommand command = new MySqlCommand(selectquery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Console.WriteLine("Category not found");
                    }
                    else
                    {
                        Console.WriteLine($" {reader["categoryid"]}, {reader["Name"]} ");
                    }
                }
            }
        }
         return null;
    }
}
