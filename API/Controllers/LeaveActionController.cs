using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveActionController : ControllerBase
    {
        private readonly IActionRepository _repo;
        private readonly IConfiguration _config;
        readonly ILogger<LogController> _log;
        private readonly IMapper _mapper;

        public LeaveActionController(IActionRepository repo, IConfiguration config, ILogger<LogController> log, IMapper mapper)
        {
            this._repo = repo;
            this._config = config;
            _log = log;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRequests()
        {
            var Requests = await _repo.GetRequests();
            var RequestsToReturn = _mapper.Map<IEnumerable<RequestsForListDto>>(Requests);
            return Ok(RequestsToReturn);
        }

        [HttpPost("response")]
        public async Task<IActionResult> LeaveResponse(ResponseDto responseDto)
        {
            
            var result = await _repo.LeaveAction(responseDto);
            if ( result == null ) 
            {
                _log.LogInformation("LeaveDays Limit Error For Request ID: " + responseDto.Id);
                return BadRequest();
            }
            _log.LogInformation(" Leave Approved for ID: " + responseDto.Id );
                
            return Ok();
            
        }

        [HttpPost("setdays")]
        public async Task<IActionResult> SetDays(int TotalDays)
        {
            var result = await _repo.Setdays(TotalDays);
            if(result == null) 
            {
                return BadRequest();
            }
            _log.LogInformation("Leave Days Set to: " + TotalDays);
            return Ok();
        }

        [HttpGet("getdays")]
        public async Task<IActionResult> GetDays()
        {
            var TotalDays = await _repo.GetDays();
            return Ok(TotalDays);
        }
        
    }
}