using AutoMapper;

namespace GroceryDeliveryAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product, DTOs.ProductDTO>();
        }
    }
}