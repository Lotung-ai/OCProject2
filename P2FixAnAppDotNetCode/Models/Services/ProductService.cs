using P2FixAnAppDotNetCode.Models.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        List<Product> productsInventory = new List<Product>();

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>

        public Product[] GetAllProducts()
        {
            // TODO change the return type from array to List<T> and propagate the change
            // throughout the application
            
            productsInventory.AddRange(_productRepository.GetAllProducts());

            return productsInventory.ToArray();

        }


        /// <summary>
        /// Get a product from the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            // TODO implement the method
            Product productId = GetAllProducts().Where(p => p.Id == id).First();
            return productId;

        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // TODO implement the method
            // update product inventory by using _productRepository.UpdateProductStocks() method.
            
            foreach (CartLine cartLine in cart.Lines)
            {
                _productRepository.UpdateProductStocks(cartLine.Product.Id, cartLine.Quantity);
         
              
            }
            var order = new Order
            {
                Date = DateTime.Now,
                Lines = cart.Lines.Select(cl => new CartLine
                {
                    OrderLineId = cl.OrderLineId,
                    Product = cl.Product,
                    Quantity = cl.Quantity
                }).ToList()
            };
            _orderRepository.Save(order);

            // Clear the cart after updating the stocks
            cart.Clear();








        }
    }


}

