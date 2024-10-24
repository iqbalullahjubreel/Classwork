using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Category
    {
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }

    //public string Electronics { get; set; }
    //public string Groceries { get; set; }

    public Category()
    {

    }
    public Category(int categoryid, string categoryName)
    {
        CategoryID = categoryid;
        CategoryName = categoryName;
    }
}
