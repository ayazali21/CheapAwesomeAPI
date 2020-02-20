using AutoMapper;
using BargainHotelSupplier;
using CheapAwesome.Domain.Models.Request;
using CheapAwesome.Domain.Settings;
using CheapAwesome.Infrastructure.Extensions;
using CheapAwesomeDomain.Models.Response;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeAPI.Service
{
    public class BargainsSupplierService : ISupplierHotelService
    {
        private readonly BargainHotelSupplierClient _client;
        private readonly IMapper _mapper;
        public BargainsSupplierService(BargainAPISettings settings, IMapper mapper,ILogger<BargainsSupplierService> logger)
        {
            
            _client = new BargainHotelSupplierClient(settings.EndPoint, settings.Code,logger);
            _mapper = mapper;
        }
        public async Task<List<HotelListResponse>> GetHotelList(GetHotelRequest request)
        {
            var response = await _client.findBargain(request.destId, request.noOfNights);
            return response.Select(x => x.ToModel(request.noOfNights)).ToList(); ;
        }
    }
}
