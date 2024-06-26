﻿using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest
{
    public class CartBLTest
    {
        IRepository<int, Product> _productRepository;
        IRepository<int, Cart> _cartRepository;
        IRepository<int, Customer> _customerRepository;
        IRepository<int, CartItem> _cartItemRepository;
        CartBL cartService;
        Product newProduct;
        Cart cart;
        Customer customer;

        [SetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository();
            newProduct = new Product(1, 100000, "Laptop", 13);
            _productRepository.Add(newProduct);

            _customerRepository = new CustomerRepository();
            customer = new Customer(1, "+91 9090909090", "bhavan", 21);
            _customerRepository.Add(customer);

            _cartRepository = new CartRepository();
            cart = new Cart(1, customer.Id);
            _cartRepository.Add(cart);

            _cartItemRepository = new CartItemRepository();

            cartService = new CartBL(_cartRepository, _productRepository, _cartItemRepository);
        }

        [Test]
        public void GenerateCartItemIdWhenEmptyTest()
        {
            int newCartId = cartService.GenerateId();

            Assert.AreEqual(1, newCartId);
        }

        [Test]
        public void GenerateCartItemIdWhenNotEmptyTest()
        {
            cart = new Cart(1, customer.Id);
            _cartRepository.Add(cart);

            int newCartId = cartService.GenerateId();

            Assert.AreEqual(2, newCartId);
        }

        [Test]
        public void AddItemToCartNotFoundException()
        {
            Exception exception = Assert.Throws<CartNotFoundException>(() => cartService.AddCartItemToCart(1, 5));

            Assert.AreEqual("No cart is found with this id: 5", exception.Message);
        }

        [Test]
        public void AddItemToCartPassTest()
        {
            Cart cart = cartService.AddCartItemToCart(1, 1);

            Assert.AreEqual(1, cart.CartItems.Count);
        }

        [Test]
        public void CalculateTotalCartAmountTest()
        {
            cartService.AddCartItemToCart(1, 1);
            CartItem cartItem = _cartItemRepository.GetByKey(1);

        }
    }
}
