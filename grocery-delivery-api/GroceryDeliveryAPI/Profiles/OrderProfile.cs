using AutoMapper;

namespace GroceryDeliveryAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Models.Order, DTOs.OrderDTO>();
        }
    }
}