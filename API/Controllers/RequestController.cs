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

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ILeaveRepository _repo;
        private readonly IConfiguration _config;
        readonly ILogger<LogController> _log;

        public RequestController(ILeaveRepository repo, IConfiguration config, ILogger<LogController> log)
        {
            this._repo = repo;
            this._config = config;
            _log = log;
        }

        [HttpPost("requests")]
        public async Task<IActionResult> Requests(LeaveRequest leaveRequest)
        {

            var RequestToSubmit = new LeaveRequest
            {
                LeaveType = leaveRequest.LeaveType ,
                StartDate = leaveRequest.StartDate ,
                EndDate = leaveRequest.EndDate ,
                Reason = leaveRequest.Reason ,
                UserId = leaveRequest.UserId 
            };

            var submittedRequest = await _repo.Request(RequestToSubmit);
            if(submittedRequest == null) 
            {
                return BadRequest();
            }
            _log.LogInformation("New Leave request Submitted by " + submittedRequest.User.Username );
            return Ok();

        }

        [HttpGet("{id}", Name = "GetLeaves")]
        public async Task<IActionResult> GetLeaves(int id)
        {
            var user = await _repo.GetUser(id);
            var LeavesToReturn = new LeavesDto
            {
                PaidLeave = user.PaidLeave,
                UnpaidLeave = user.UnpaidLeave
            };
            return Ok(LeavesToReturn);
        }
        
    }
}