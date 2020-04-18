﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeveloperExceptionMiddleware.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThrowExceptionController : ControllerBase
    {
        private readonly ILogger<ThrowExceptionController> _logger;

        public ThrowExceptionController(ILogger<ThrowExceptionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new SuperSpecialException();
        }
    }
}