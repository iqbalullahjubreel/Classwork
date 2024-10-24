using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Admin
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }

    public Admin()
    {

    }
    public Admin(string email, string password ,string name)
    {

        Email = email;
        Name = name;
        Password = password;
    }
}
