using Microsoft.AspNetCore.Mvc;
using Katio.Data.Models;
using Katio.Business.Interfaces;
using System.Net;
using Katio_net.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Katio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet]
    [Route("HealthCheck")]
    public async Task<IActionResult> GetHealth()
    {
        return Ok();
    }
}