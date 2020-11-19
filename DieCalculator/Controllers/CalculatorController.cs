using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DieCalculator.Models;
using DieCalculator.Models.ViewModels;
using DieCalculator.Helpers;

namespace DieCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Calculate([FromBody]DieFormSubmit calcParams)
        {
            var retvm = CalculatorHelper.CalculateDiceProb(calcParams);
            return Json(retvm);
        }
    }
}
