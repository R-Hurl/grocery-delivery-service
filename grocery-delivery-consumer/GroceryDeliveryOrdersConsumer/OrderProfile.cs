using AutoMapper;

namespace GroceryDeliveryOrdersConsumer
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Models.Order, Order>();
            CreateMap<Models.Address, Address>();
            CreateMap<Models.CartItem, CartItem>();
            CreateMap<Models.Product, Product>();
        }
    }
}