using P2FixAnAppDotNetCode.Models.Repositories;
<<<<<<< HEAD
using Remotion.Linq.Clauses;
=======
>>>>>>> b88ea14ae962011dd9403e0be90b53b19ce7d7fd
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
<<<<<<< HEAD


        public List<Product> GetAllProducts()
        {
            // TODO change the return type from array to List<T> and propagate the change
            // throughout the application
            List<Product> productsInventory = new List<Product>();
            productsInventory.AddRange(_productRepository.GetAllProducts());

            return productsInventory;

        }


        /// <summary>
        /// Get a product from the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            // TODO implement the method

=======
  
           
            public List<Product> GetAllProducts()
            { 
            // TODO change the return type from array to List<T> and propagate the change
            // throughout the application

                return _productRepository.GetAllProducts();
            }


            /// <summary>
            /// Get a product form the inventory by its id
            /// </summary>
            public Product GetProductById(int id)
        {
            // TODO implement the method
            Console.WriteLine(_productRepository.GetProductById(id));
>>>>>>> b88ea14ae962011dd9403e0be90b53b19ce7d7fd
            return _productRepository.GetProductById(id);

        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // TODO implement the method
            // update product inventory by using _productRepository.UpdateProductStocks() method.

<<<<<<< HEAD



            foreach (var cartLine in cart.Lines)
            {
                _productRepository.UpdateProductStocks(cartLine.Product.Id, cartLine.Quantity);


            }
            Order order = new Order
            {
                Lines = cart.Lines.Select(cartLine => new CartLine
                {
                    Product = cartLine.Product,
                    Quantity = cartLine.Quantity
                }).ToList()
            };

            _orderRepository.Save(order);
            var products = _productRepository.GetAllProducts();
=======
>>>>>>> b88ea14ae962011dd9403e0be90b53b19ce7d7fd
        }
    }


    }

