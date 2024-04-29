using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Customer
    {
        public int Id { get; set; }
        public string Phone { get; set; } = String.Empty;
        public string Name { get; set; }
        public int Age { get; set; }

        public Customer(int id, string phone, string name, int age)
        {
            Id = id;
            Phone = phone;
            Name = name;
            Age = age;
        }
    }

    
}
