using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_demo_1.Models;

namespace webapi_demo_1.Filters
{
    public class ApiErrorFilter : IExceptionFilter
    {
        private IHostingEnvironment _env;
        public ApiErrorFilter(IHostingEnvironment env)
        {
            _env = env;
        }
        public void OnException(ExceptionContext context)
        {
            var apiError = new ApiError();         
            if(_env.IsDevelopment())
            {
                apiError.Message = context.Exception.Message;
                apiError.Details = context.Exception.StackTrace;
            }
            else
            {
                apiError.Message = "An error has occured in the server";
                apiError.Details = context.Exception.Message;
            }

            var objectResult = new ObjectResult(apiError) {
                StatusCode = 500
            };
            context.Result = objectResult;
            
        }
    }
}
