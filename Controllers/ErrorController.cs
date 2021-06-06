using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statuscodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode) 
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resoure you requested could not be found.";
                    logger.LogWarning($"404 Error occured. Path = {statuscodeResult.OriginalPath}" 
                        +$" and QueryString = {statuscodeResult.OriginalQueryString}");
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError($"The path {exceptionHandler.Path} threw an exception" 
                + $"{exceptionHandler.Error}");

            return View("Error");
        }
    }
}
