using CheapAwesome.Domain.Models.Request;
using CheapAwesomeDomain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeAPI.Service
{
    public interface ISupplierHotelService
    {
        Task<List<HotelListResponse>> GetHotelList(GetHotelRequest request);
    }
}
