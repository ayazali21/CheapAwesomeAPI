using CheapAwesome.API.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ServiceFilter(typeof(ApiExceptionFilter))]
    [ValidateModel]
    public class BaseController : ControllerBase
    {
    }
}
