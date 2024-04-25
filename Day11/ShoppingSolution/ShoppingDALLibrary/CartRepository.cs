using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Delete(int key)
        {
            Cart cart = GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }

        public override Cart GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new ProductNotFoundException(key);
        }

        public override Cart Add(Cart newCart)
        {
            bool cartExist = false;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == newCart.Id) throw new CartDuplicationException(newCart.Id);
            }

            items.Add(newCart);
            return newCart;
        }

        public override List<Cart> GetAll()
        {
            if (items.Count == 0) throw new NoCartsFoundException();

            return items;
        }

        public override Cart Update(Cart item)
        {
            Cart cartToBeUpdated = items.Find(cart => cart.Id == item.Id);

            if (cartToBeUpdated == null) throw new CartNotFoundException(item.Id);

            cartToBeUpdated.Id = item.Id;
            cartToBeUpdated.CustomerId = item.CustomerId;
            cartToBeUpdated.Customer = item.Customer;
            cartToBeUpdated.CartItems = item.CartItems;

            return cartToBeUpdated;
        }

    }
}
