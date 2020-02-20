using AutoMapper;
using BargainHotelSupplier.Models.BargainSupplierModel.Response;
using CheapAwesomeDomain.Enum;
using CheapAwesomeDomain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesome.Infrastructure.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<FindBargainsApiResponse, HotelListResponse>()
               .ForMember(s => s.SupplierType, d => d.MapFrom(x => SupplierType.BargainHotel.ToString()))
               .ForMember(s => s.HotelInformation, d => d.MapFrom(x => x.Hotel))
               .ForMember(s => s.Price, d => d.MapFrom(x => x.Rates));

            CreateMap<Hotel, HotelInformationModel>()
                              .ForMember(s => s.Name, d => d.MapFrom(x => x.Name))
                              .ForMember(s => s.PropertyId, d => d.MapFrom(x => x.PropertyId))
                              .ForMember(s => s.Rating, d => d.MapFrom(x => x.Rating))
                              .ForMember(s => s.GeoId, d => d.MapFrom(x => x.GeoId));

            CreateMap<Rate, HotelPriceModel>()
              .ForMember(s => s.BoardType, d => d.MapFrom(x => x.BoardType))
               .ForMember(s => s.RateType, d => d.MapFrom(x => x.RateType.ToString()))
               .ForMember(s => s.Price, d => d.MapFrom(x => x.Value));
        }

    }
}
