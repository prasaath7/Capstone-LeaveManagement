using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        readonly ILogger<LogController> _log;

    public LogController(ILogger<LogController> log)
    {
        _log = log;
    }

    public void LogInfo (string msg )
    {
        _log.LogInformation(msg);
    }
    }
}