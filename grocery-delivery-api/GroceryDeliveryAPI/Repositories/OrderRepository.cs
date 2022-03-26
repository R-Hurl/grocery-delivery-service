using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GroceryDeliveryAPI.DTOs;
using GroceryDeliveryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryDeliveryAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GroceryDeliveryServiceContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public OrderRepository(GroceryDeliveryServiceContext dbContext, IMapper mapper, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<OrderItemDTO>> GetOrderItemsAsync(string orderId)
        {
            var orderIdGuid = Guid.Parse(orderId);
            var orderItemsFromDB = await _dbContext.OrderItems.Where(
                oi => oi.OrderId == orderIdGuid
            ).ToListAsync();

            var orderItems = new List<OrderItemDTO>();
            foreach (var item in orderItemsFromDB)
            {
                var product = await _productRepository.GetProductByIdAsync(item.ProductId);
                var orderItem = new OrderItemDTO
                {
                    Product = _mapper.Map<Models.Product, DTOs.ProductDTO>(product),
                    Quantity = item.Quantity
                };

                orderItems.Add(orderItem);
            }

            return orderItems;
        }

        public async Task<List<OrderDTO>> GetOrdersAsync()
        {
            var orders = await _dbContext.Orders.ToListAsync();
            return _mapper.Map<List<Models.Order>, List<DTOs.OrderDTO>>(orders);
        }
    }
}