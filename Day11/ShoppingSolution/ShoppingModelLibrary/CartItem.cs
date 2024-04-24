using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }//Navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; }//Navigation property
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }

        public CartItem(int productId, Product product)
        {
            CartId = -1;
            ProductId = productId;
            Product = product;
            Quantity = 1;
            Price = product.Price;
            Discount = 0;
            PriceExpiryDate = DateTime.Today.AddDays(1);
        }
    }
}
