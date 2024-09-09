using AutoMapper;
using DtoLayer.BasketDto;
using EntityLayer.Entities;

namespace Api.Mapping
{
    public class BasketMapping:Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket,CreateBasketDto>().ReverseMap();
        }
    }
}
