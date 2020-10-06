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
using AutoMapper;

namespace LM.UnitTest
{
    [TestFixture]
    class LeaveActionControllerTest
    {
        private readonly LeaveActionController _sut;
        private readonly Mock<IActionRepository> _actionRepoMock = new Mock<IActionRepository>();
        private readonly Mock<IConfiguration> _configMock = new Mock<IConfiguration>();
        private readonly Mock<ILogger<LogController>> _logMock = new Mock<ILogger<LogController>>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public LeaveActionControllerTest()
        {
            _sut = new LeaveActionController(_actionRepoMock.Object, _configMock.Object, _logMock.Object , _mapperMock.Object);
        }
        [Test]
        public async Task LeaveResponse_Approved_Ok()
        {
            var responseDto = new ResponseDto
            {
                Id = 20,
                LeaveApproved = true
            };

            _actionRepoMock.Setup(x => x.LeaveAction(responseDto)).ReturnsAsync(new LeaveRequest { Id =5 });


            var result = await _sut.LeaveResponse(responseDto);


            Assert.That(result, Is.TypeOf<OkResult>());


        }
        [Test]
        public async Task LeaveResponse_NotinRange_Bad()
        {
            var responseDto = new ResponseDto
            {
                Id = 20,
                LeaveApproved = false
            };

            _actionRepoMock.Setup(x => x.LeaveAction(responseDto)).ReturnsAsync(() => null);


            var result = await _sut.LeaveResponse(responseDto);


            Assert.That(result, Is.TypeOf<BadRequestResult>());


        }
        [Test]
        public async Task SetDays_setted_Ok()
        {
            int TotalDays = 20;

            _actionRepoMock.Setup(x => x.Setdays(TotalDays)).ReturnsAsync(new LeaveDays { Id =1 , TotalLeave = 20 });


            var result = await _sut.SetDays(TotalDays);


            Assert.That(result, Is.TypeOf<OkResult>());


        }

        [Test]
        public async Task SetDays_Notsetted_Bad()
        {
            int TotalDays = 20;

            _actionRepoMock.Setup(x => x.Setdays(TotalDays)).ReturnsAsync(()=> null);


            var result = await _sut.SetDays(TotalDays);


            Assert.That(result, Is.TypeOf<BadRequestResult>());


        }
    }
}
