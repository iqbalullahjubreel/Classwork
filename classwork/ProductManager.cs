using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductManager
{
    private static List<Product> products = new List<Product>();

    private static string ConnectionStringWithoutDB = "server=localhost;User=root;password=oladapo";
    private static string ConnectionString = "server=localhost;User=root;database=ProductDataBase;password=oladapo";
    public static void CreateProductDB()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionStringWithoutDB))
        {
            connection.Open();
            string query = "Create Database if not exists ProductDataBase";

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

    public static void CreateProductTable()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "create table if not exists ProductDataBase.Product(id int primary Key not null auto_increment, Name varchar(255) Not Null, Quantity int(23) , CategoryId int(23) , ProductId int(23), Price decimal(23), Category varchar(200) not null);";

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

    public static void CreateProduct(Product product)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            Category category1 = new Category();
            connection.Open();
            Console.WriteLine("Enter the name of the product");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the quantity");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the price of the goods");
            decimal price = decimal.Parse(Console.ReadLine()); 
            Console.WriteLine("Select the category");
            string category = Console.ReadLine();
            Console.WriteLine("enter productId");
            int proid = int.Parse(Console.ReadLine());
            Console.WriteLine("enter CategoryId");
            int catid = int.Parse(Console.ReadLine());

            var registerUser = new Product(name ,quantity ,price ,category);
            products.Add(registerUser);
            if(product.Category == category1.CategoryName)
            {
                MySqlCommand insert = new MySqlCommand($"insert into Product(name,quantity,price,category,CategoryId,ProductId) values('{product.Name = name}','{product.Quantity = quantity}','{product.Price = price}','{product.Category = category}','{product.CategoryId = catid}','{product.ProductId = proid}');", connection);

                var execute = insert.ExecuteNonQuery();

                if (execute == 0)
                {
                    Console.WriteLine("Product Created Successfully.");
                }
                else
                {
                    Console.WriteLine("Unable To Create Product.");
                }
            }
        }
    }
    public static void UpdateProduct(Product product)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Console.WriteLine("Enter the new Name of the product");
            string newname = Console.ReadLine();
            Console.WriteLine("Enter the quantity");
            int newquantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the price of the goods");
            decimal newprice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the category");
            string newcategory = Console.ReadLine();
            Console.WriteLine("enter the id of the table you want to update");
            int id = int.Parse(Console.ReadLine());

            product.Name = newname;
            product.Quantity = newquantity;
            product.Price = newprice;
            product.Category = newcategory;

            string Query = $"Update ProductDataBase.Product SET name = '{product.Name}',quantity ='{product.Quantity}',price ='{product.Price}',category ='{product.Category}' where id = {id}";
            MySqlCommand command = new MySqlCommand(Query, connection);
            var execute = command.ExecuteNonQuery();
            if (execute > 0)
            {
                Console.WriteLine("Product table updated sucessfully");
            }
            else
            {
                Console.WriteLine("unable update Product table");
            }
        }
    }
    public static void DeleteProduct()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Console.WriteLine("Enter the id of the product you want to delete");
            int id = int.Parse(Console.ReadLine());
            string query = $"DELETE from ProductDataBase.Product  where id = {id};";
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
    public static void GetAllProduct()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string selectquery = "SELECT id, name,quantity,price, category FROM ProductDataBase.Product";
            using (MySqlCommand command = new MySqlCommand(selectquery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("User in database:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"NAME {reader["name"]}, PRICE: {reader["price"]}, CATEGORY: {reader["category"]}, QUANTITY: {reader["quantity"]}\n ");
                    }
                }
            }
        }
    }
    public static Product GetProduct(int id)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string selectquery = $"SELECT id, name,quantity,price, category FROM Product WHERE id = {id}";

            using (MySqlCommand command = new MySqlCommand(selectquery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Console.WriteLine("product not found");
                    }
                    else
                    {
                        Console.WriteLine($"PRODUCT NAME {reader["name"]}, CATEGORY: {reader["category"]}, PRICE: {reader["price"]} , QUANTITY: {reader["quantity"]}");
                    }
                }
            }
        }
        return null;
    }

    public static Product ChecklowStockProduct(Product product1)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string selectquery = $"SELECT id, name,quantity,price, category FROM Product WHERE id";

            using (MySqlCommand command = new MySqlCommand(selectquery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Console.WriteLine("Product not found");
                    }
                    else
                    {
                        Product admin = new Product();
                        admin.Name = reader.GetString(1);
                        admin.Quantity = reader.GetInt32(2);
                        if(admin.Quantity <=5)
                        {
                        Console.WriteLine("you are running out of stock");
                        }
                        else
                        {
                            Console.WriteLine("Stocks available abundantly");
                        }
                    }
                }
            }
        }
        return null;
    }

    public static void GenerateSalesRecord()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string selectquery = "SELECT id, name,quantity,price, category FROM ProductDataBase.Product";
            using (MySqlCommand command = new MySqlCommand(selectquery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("User in database:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"NAME {reader["name"]}, PRICE: {reader["price"]}, CATEGORY: {reader["category"]}, QUANTITY: {reader["quantity"]}\n ");
                    }
                }
            }
        }
    }
}
