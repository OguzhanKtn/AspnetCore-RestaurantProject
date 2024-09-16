using AutoMapper;
using DtoLayer.TableDto;
using EntityLayer.Entities;

namespace Api.Mapping
{
	public class TableMapping : Profile
	{
        public TableMapping()
        {
            CreateMap<Table,ResultTableDto>().ReverseMap();
            CreateMap<Table,CreateTableDto>().ReverseMap();
            CreateMap<Table,UpdateTableDto>().ReverseMap();
        }
    }
}
