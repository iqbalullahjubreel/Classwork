using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Product
{
   public int CategoryId {  get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }

    public Product()
    {

    }
    public Product(string name, int quantity, decimal price,  string category)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
        Category = category;
    }


}
