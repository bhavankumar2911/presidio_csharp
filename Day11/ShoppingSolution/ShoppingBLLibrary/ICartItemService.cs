using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public enum CartItemUpdateType
    {
        Increase,
        Decrease
    }

    public interface ICartItemService
    {
        CartItem CreateCartItem(Product product);

        //CartItem UpdateCartItemCount(int cartItemId, CartItemUpdateType cartItemUpdateType);
    }
}
