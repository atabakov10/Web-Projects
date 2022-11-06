﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public IActionResult GetCurrentTime()
        {
            return Ok(new { currentTime = DateTime.Now.ToLocalTime() });
        }
    }
}
