using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    internal class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override CartItem Delete(int key)
        {
            CartItem cartItem = GetByKey(key);
            if (cartItem != null)
            {
                items.Remove(cartItem);
            }
            return cartItem;
        }

        public override CartItem GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new ProductNotFoundException(key);
        }

        public override CartItem Add(CartItem newCartItem)
        {
            bool cartItemExists = false;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == newCartItem.Id) throw new CartItemDuplicationException(newCartItem.Id);
            }

            items.Add(newCartItem);
            return newCartItem;
        }

        public override List<CartItem> GetAll()
        {
            if (items.Count == 0) throw new NoCartItemsFoundException();

            return items;
        }

        public override CartItem Update(CartItem item)
        {
            CartItem cartItemToBeUpdated = items.Find(cartItem => cartItem.Id == item.Id);

            if (cartItemToBeUpdated == null) throw new CartItemNotFoundException(item.Id);

            cartItemToBeUpdated.Quantity = item.Quantity;
            cartItemToBeUpdated.Price = item.Price;
            cartItemToBeUpdated.Discount = item.Discount;
            cartItemToBeUpdated.PriceExpiryDate = item.PriceExpiryDate;

            return cartItemToBeUpdated;
        }

    }
}
