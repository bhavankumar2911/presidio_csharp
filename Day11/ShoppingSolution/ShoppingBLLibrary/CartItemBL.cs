using ShoppingBLLibrary.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
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
        readonly IRepository<int, Cart> _cartRepository;
        readonly IRepository<int, Product> _productRepository;
        readonly IRepository<int, Customer> _customerRepository;

        public CartItemBL(IRepository<int, CartItem> cartItemRepository, IRepository<int, Cart> cartRepository, IRepository<int, Product> productRepository, IRepository<int, Customer> customerRepository)
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        private int GenerateId ()
        {
            int maxId = Int32.MinValue;
            List<Cart> cart = (List<Cart>)_cartRepository.GetAll();

            foreach (var cartItem in cart)
            {
                maxId = Math.Max(maxId, cartItem.Id);
            }

            return ++maxId;
        }

        public CartItem CreateCartItem(Product product, int cartId)
        {
            CartItem cartItem;
            try
            {
                // check product is available - throws exception
                Product availableProduct = _productRepository.GetByKey(product.Id);

                // check product quantity
                if (availableProduct.QuantityInHand < 1)
                {
                    throw new ProductOutOfStockException(availableProduct.Name);
                }

                // checking cart - throws exception
                Cart cart = _cartRepository.GetByKey(cartId);

                // update product quantity
                availableProduct.QuantityInHand--;
                _productRepository.Update(availableProduct);

                // create cart item
                cartItem = new CartItem(GenerateId(), availableProduct, cartId);
                
                return cartItem;
            }
            catch (Exception)
            {
                throw;
            }
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
