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
    class AuthControllerTest
    {
        private readonly AuthController _sut;
        private readonly Mock<IAuthRepository> _authRepoMock = new Mock<IAuthRepository>();
        private readonly Mock<IConfiguration> _configMock = new Mock<IConfiguration>();
        private readonly Mock<ILogger<LogController>> _logMock = new Mock<ILogger<LogController>>();

        public AuthControllerTest()
        {
            _sut = new AuthController(_authRepoMock.Object, _configMock.Object, _logMock.Object);
        }

        [Test]
        public async Task Register_IfNewUser_return_Ok()
        {
            var userForRegisterDto = new UserForRegisterDto
            {
                Username = "NewName",
                Email = "abc@gmail.com",
                Password = "123456"
                
            };
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
                Email = userForRegisterDto.Email
            };
            _authRepoMock.Setup(x => x.Register(userToCreate, userForRegisterDto.Password)).ReturnsAsync(userToCreate);


            var result = await _sut.Register(userForRegisterDto);


            Assert.That(result, Is.TypeOf<OkResult>());
       
            
        }

        [Test]
        public async Task Login_IfINCOrrect_returnUnAuthorized()
        {
            var userForLoginDto = new UserForLoginDto
            {
                Username = "NewName",
                Password = "123456"
            };
            var user = new User
            {
                Username = userForLoginDto.Username
            };
            _authRepoMock.Setup(x => x.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password)).ReturnsAsync(()=> null);

            var result = await _sut.Login(userForLoginDto);

            Assert.That(result, Is.TypeOf<UnauthorizedResult>());
        }
    }
}
