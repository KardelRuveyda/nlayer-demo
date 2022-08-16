using Microsoft.AspNetCore.Mvc;
using NLayerDemo.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerDemo.API.Controllers
{
    public class CustomBaseController : Controller
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(GlobalResponseDto<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
