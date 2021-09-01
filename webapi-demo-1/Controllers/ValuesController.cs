using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_demo_1.Controllers
{
    [ApiController]
    [Route("/[Controller]/")]
    public class ValuesController : ControllerBase
    {
       private string[] _values = new string[] { "a", "b" };

        [Route("")]
        [Route("all")]
        [HttpGet("test")]
        [ProducesResponseType(200)]
       public ActionResult<IEnumerable<string>> Items()
        {
            return _values;
        }

        [Route("item/{pos:int:range(0,1)}")]
        public ActionResult<string> Item(int pos)
        {
            return _values[pos];
        }

        [HttpPost()]
        public ActionResult<IEnumerable<string>> Item([FromBody] string item)
        {
            _values = _values.Union<string>(new string[] { item }).ToArray<string>();
            return _values;
        }

        [HttpDelete()]
        public ActionResult<IEnumerable<string>> DeleteItem(string item)
        {
            if(_values.Contains(item))
            {
                _values = _values.Where(val => val != item).ToArray();
            }
           return _values;
        }
    }
}
