using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheapAwesome.API.Infrastructure.Filters;
using CheapAwesome.Domain.Models.Request;
using CheapAwesome.Domain.Models.Response;
using CheapAwesomeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using CheapAwesomeDomain.Models.Response;
using System.Net;

namespace CheapAwesomeAPI.Controllers
{
    [ApiVersion("1.0")]
    public class CheapAwesomeController : BaseController
    {
        private readonly ILogger<CheapAwesomeController> _logger;
        private readonly ISupplierHotelService _service;

        public CheapAwesomeController(ILogger<CheapAwesomeController> logger,ISupplierHotelService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HotelListResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetHotels([FromQuery]GetHotelRequest request )
        {
            //if (destId == 0 || noOfNights == 0)
            //    return BadRequest() as IActionResult;
            var timer = new Stopwatch();
            _logger.LogInformation($"{nameof(CheapAwesomeController)} - {nameof(GetHotels)} - called");
            timer.Start();
            var response = await _service.GetHotelList(new GetHotelRequest() { destId = request.destId, noOfNights = request.noOfNights });
            timer.Stop();
            _logger.LogInformation($"{nameof(GetHotels)}- took {timer.ElapsedMilliseconds} mili-seconds");
            return response != null ? Ok(CommonResponse.CreateSuccessResponse($"Success with response time :{timer.ElapsedMilliseconds} mili secs",response)) : BadRequest() as IActionResult;
        }
    }
}