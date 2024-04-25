using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override Product Add (Product newProduct)
        {
            bool productExist = false;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == newProduct.Id) throw new ProductDuplicationException(newProduct.Id);
            }

            items.Add(newProduct);
            return newProduct;
        }

        public override List<Product> GetAll ()
        {
            if ( items.Count == 0 ) throw new NoProductsFoundException();

            return items;
        }

        public override Product Delete(int key)
        {
            Product product = GetByKey(key);

            if (product != null)
            {
                items.Remove(product);
            }

            return product;
        }

        public override Product GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }

            throw new ProductNotFoundException(key);
        }

        public override Product Update(Product item)
        {
            Product productToBeUpdated = items.Find(product => product.Id == item.Id);

            if (productToBeUpdated == null) throw new ProductNotFoundException(item.Id);

            productToBeUpdated.Id = item.Id;
            productToBeUpdated.Name = item.Name;
            productToBeUpdated.Price = item.Price;
            productToBeUpdated.Image = item.Image;
            productToBeUpdated.QuantityInHand = item.QuantityInHand;

            return productToBeUpdated;
        }
    }
}
