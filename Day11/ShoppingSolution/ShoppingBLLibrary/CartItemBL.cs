using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartItemBL : ICartItemService
    {
        readonly IRepository<int, CartItem> _cartItemRepository;
        public CartItemBL(IRepository<int, CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public CartItem CreateCartItem(Product product)
        {
            CartItem cartItem = new CartItem(product.Id, product);
            return cartItem;
        }

        //public CartItem UpdateCartItemCount(int cartItemId, CartItemUpdateType cartItemUpdateType)
        //{
        //    CartItem cartItem = _cartItemRepository.GetByKey(cartItemId);

        //    if (cartItem != null)
        //    {
        //        if (cartItemUpdateType == CartItemUpdateType.Increase)
        //        {

        //        }
        //    }
        //}
    }
}
