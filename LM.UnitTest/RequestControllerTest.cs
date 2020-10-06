using API.Controllers;
using API.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using API.Dtos;
using System.Net;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LM.UnitTest
{
    [TestFixture]
    class RequestControllerTest
    {
        private readonly RequestController _sut;
        private readonly Mock<ILeaveRepository> _leaveRepoMock = new Mock<ILeaveRepository>();
        private readonly Mock<IConfiguration> _configMock = new Mock<IConfiguration>();
        private readonly Mock<ILogger<LogController>> _logMock = new Mock<ILogger<LogController>>();

        public RequestControllerTest()
        {
            _sut = new RequestController(_leaveRepoMock.Object, _configMock.Object, _logMock.Object);
        }

        [Test]
        public async Task Requests_IfNotSubmitted_return_BadRequest()
        {
            var RequestToSubmit = new LeaveRequest
            {
                LeaveType = "paid",
                StartDate = new DateTime(2020, 10, 10),
                EndDate = new DateTime(2020, 10, 13),
                Reason = "Fever",
                UserId = 5
            };

            _leaveRepoMock.Setup(x => x.Request(RequestToSubmit)).ReturnsAsync(()=> null);


            var result = await _sut.Requests(RequestToSubmit);

            


            Assert.That(result, Is.TypeOf<BadRequestResult>());


        }
    }
}
