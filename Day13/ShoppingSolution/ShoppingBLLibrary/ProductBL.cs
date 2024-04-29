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
    public class ProductBL
    {
        readonly IRepository<int, Product> _productRepository;

        public ProductBL(IRepository<int, Product> productRepository) 
        {
            _productRepository = productRepository;
        }

        public Product CheckAndUpdateProductBeforeAddingToCart (int productId)
        {
            try
            {
                // check product available
                Product availableProduct = _productRepository.GetByKey(productId);

                // checking stock
                if (availableProduct.QuantityInHand < 1)
                {
                    throw new ProductOutOfStockException(availableProduct.Name);
                }

                // update product repo
                availableProduct.QuantityInHand--;
                _productRepository.Update(availableProduct);

                return availableProduct;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
