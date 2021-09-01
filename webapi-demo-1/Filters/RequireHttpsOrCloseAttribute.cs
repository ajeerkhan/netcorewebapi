using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_demo_1.Models;

namespace webapi_demo_1.Filters
{
    public class RequireHttpsOrCloseAttribute : RequireHttpsAttribute 
    {
        protected override void HandleNonHttpsRequest(AuthorizationFilterContext filterContext)
        {
            //filterContext.Result = new StatusCodeResult(500);
            var apiError = new ApiError();
            apiError.Message = "Http is not supportd.";
            apiError.Details = "Application do not support HTTP, use Https.";
            filterContext.Result = new ObjectResult(apiError)
            {
                StatusCode = 500
            };
        }
    }
}
