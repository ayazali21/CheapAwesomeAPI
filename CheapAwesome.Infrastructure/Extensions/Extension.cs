using BargainHotelSupplier.Models.BargainSupplierModel.Response;
using CheapAwesomeDomain.Enum;
using CheapAwesomeDomain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheapAwesome.Infrastructure.Extensions
{
    public static class Extension
    {
        public static HotelListResponse ToModel(this FindBargainsApiResponse model,int noOfNight)
        {
            return new HotelListResponse()
            {
                HotelInformation = model.Hotel.ToModel(),
                Price = model.Rates.Select(x => x.ToModel(noOfNight)).ToList(),
                SupplierType = SupplierType.BargainHotel.ToString(),
                
            };
        }

        public static HotelInformationModel ToModel(this Hotel model)
        {
            return new HotelInformationModel()
            {
                Name = model.Name,
                GeoId = model.GeoId,
                PropertyId = model.PropertyId,
                Rating = model.Rating,
                
            };
        }
        public static HotelPriceModel ToModel(this Rate model,int noOfNight)
        {
            return new HotelPriceModel()
            {
                BoardType = model.BoardType,
                Price = model.RateType == RateType.PerNight.ToString() ? (noOfNight * model.Value) : model.Value,
                RateType =model.RateType.ToString()
            };
        }
    }
}
