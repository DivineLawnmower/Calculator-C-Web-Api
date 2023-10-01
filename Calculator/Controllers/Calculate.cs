﻿using Calculator.Services.Calculator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Calculate : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICalculatorService _calculatorService;
        public Calculate(IHttpContextAccessor httpContextAccessor, ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
            _contextAccessor = httpContextAccessor;
        }     

        // POST: Calculate/Create
        [HttpPost]
        public IActionResult CalculateExpression(string expression)
        {
            try
            {

                var result = _calculatorService.Calculate(expression);
                if(result.Success)
                {
                    return Ok(result.Result);
                } 
                return BadRequest(result.Message);  
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}