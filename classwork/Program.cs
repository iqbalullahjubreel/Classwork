// See https://aka.ms/new-console-template for more information
using Ubiety.Dns.Core;

Console.WriteLine("Hello, World!");
Admin admin = new Admin();
User users = new User();
Product product = new Product();
Category category = new Category();
//CategoryManager.CreateCategory(category);
//ProductManager.CreateProduct(product);
//UserManager.CreateUserDB();
//UserManager.CreateUserTable();
//UserManager.CreateUser(users);
//ProductManager.CreateProductDB();
ProductManager.CreateProductTable();
//ProductManager.CreateProduct(product);
//ProductManager.UpdateProduct(product);
//CategoryManager.CreateCategoryTable();
//ProductManager.GetAllProduct();
//ProductManager.CreateProduct(product);
//CategoryManager.CreateCategory(product);
//Console.WriteLine("enter the id of the table you want to delete");
//int id = int.Parse(Console.ReadLine());
//ProductManager.GetProduct(id);
//ProductManager.DeleteProduct();
//AdminManager.CreateAdminDB();
//AdminManager.CreateAdminTable();
//AdminManager.CreateAdmin(admin);
//Console.WriteLine("Enter your Email");
//string email = Console.ReadLine();
//Console.WriteLine("Enter your Password");
//string password = Console.ReadLine();
//AdminManager.LoginAdmin(email, password);

//CategoryManager.CreateCategoryDB();
//CategoryManager.CreateCategoryTable();
//CategoryManager.CreateCategory(category);
//CategoryManager.DeleteCategory();
//CategoryManager.GetAllCategories();
//Console.WriteLine("enter the id of the table you want to delete");
//int ide = int.Parse(Console.ReadLine());
//CategoryManager.GetCategory(ide);




bool runnings = true;

while (runnings)
{
    Console.WriteLine("Welcome to Quiz Driller App \n press any key to continue \n");
    Console.ReadKey();
    Console.WriteLine("1. Register");
    Console.WriteLine("2.login");
    Console.WriteLine("3. Exit");
    Console.WriteLine("choose an option");
    string opt = Console.ReadLine();
    switch (opt)
    {
        case "1":
            UserManager.CreateUser(users);
            break;
        case "2":
            Console.WriteLine("enter your Email");
            string emails = Console.ReadLine();
            Console.WriteLine("enter password");
            int passwords = int.Parse(Console.ReadLine());
            var loggedInUser = UserManager.LoginUser(emails, passwords);
            bool loggedIn = true;
            if (loggedInUser != null)
            {
                if (loggedInUser.AdminEmail == emails)
                {
                    while (loggedIn)
                    {
                        Console.WriteLine("1: ADD PRODUCTS");
                        Console.WriteLine("2: Update Product");
                        Console.WriteLine("3: Check all products");
                        Console.WriteLine("4: Get a product");
                        Console.WriteLine("5. Delete a product");
                        Console.WriteLine("6: Get all categories");
                        Console.WriteLine("7: Check if Product Available is low");
                        Console.WriteLine("8: Exit");
                        Console.Write("Choose an option: ");
                        string choices = Console.ReadLine();
                        switch (choices)
                        {
                            case "1":
                                ProductManager.CreateProduct(product);
                                CategoryManager.CreateCategory(category);
                                break;
                            case "2":
                                ProductManager.UpdateProduct(product);
                                break;
                            case "3":
                                ProductManager.GetAllProduct();
                                break;
                            case "4":
                                Console.WriteLine("enter the id of the product you want to get");
                                int id = int.Parse(Console.ReadLine());
                                ProductManager.GetProduct(id);
                                break;
                            case "5":
                                ProductManager.DeleteProduct();
                                break;
                            case "6":
                                CategoryManager.GetAllCategories();
                                break;
                            case "7":
                                ProductManager.ChecklowStockProduct(product);
                                break;
                            case "8":
                                loggedIn = false;
                                break;
                        }
                    }
                }
                else if (loggedInUser.Email == emails)
                {
                    while (loggedIn)
                    {
                        Console.WriteLine("1. Buy product");
                        Console.WriteLine("2. Update your information");
                        Console.WriteLine("3. Check your information");
                        Console.WriteLine("4. Exit");
                        Console.Write("Choose an option: ");
                        string loginChoice = Console.ReadLine();
                        switch (loginChoice)
                        {
                            case "1":
                                //QuestionManager.StartQuiz();
                                break;
                            case "2":
                                UserManager.UpdateUser(users);
                                break;
                            case "3":
                                Console.WriteLine("enter your id");
                                int iden = int.Parse(Console.ReadLine());
                                UserManager.GetUser(iden);
                                break;
                            case "4":
                                loggedIn = false;
                                break;
                        }
                    }
                }
            }
            break;
        case "5":
            runnings = false;
            break;
    }
}
