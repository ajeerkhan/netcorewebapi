using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_demo_1.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RoomsController: ControllerBase
    {
        //[HttpGet(Name = nameof(GetRooms))]
       [Route("", Name = nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}
