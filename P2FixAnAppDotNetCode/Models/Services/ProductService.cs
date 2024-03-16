﻿using P2FixAnAppDotNetCode.Models.Repositories;
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
            List<Product> productsInventory = _productRepository.GetAllProducts().ToList();
            productsInventory = _productRepository.GetAllProducts().ToList();

            List<Order> orders = _orderRepository.GetAllOrders();

            foreach (Order order in orders)
            {
                foreach (CartLine orderLine in order.Lines)
                {
                    Product productToUpdate = productsInventory.FirstOrDefault(p => p.Id == orderLine.Product.Id);

                    if (productToUpdate != null)
                    {
                        productToUpdate.Stock -= orderLine.Quantity;
                        if (productToUpdate.Stock <= 0)
                        {
                            productsInventory.Remove(productToUpdate);
                        }
                    }
                }
            }
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
            // update product inventory by using _productRepository.UpdateProductStocks() method.                      0
            int id = 0;
            foreach (CartLine cartLine in cart.Lines)
            {
                id++;
                _productRepository.UpdateProductStocks(cartLine.Product.Id, cartLine.Quantity);
                
            }
            Order order = new Order
            {
          OrderId= id,
                Date = DateTime.Now,
                Lines = cart.Lines.ToArray()
            };
            _orderRepository.Save(order);
        }
    }
}

