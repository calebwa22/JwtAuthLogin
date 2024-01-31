using JwtAuthLogin.Core.DbContext.Dtos;
using JwtAuthLogin.Core.Entities;
using JwtAuthLogin.Core.Interfaces;
using JwtAuthLogin.Core.OtherObjects;
using JwtAuthLogin.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // route for seeding my roles to DB
        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seerRoles = await _authService.SeedRolesAsync();
            return Ok(seerRoles);
        }

        // route -> register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var registerResult = await _authService.registerAsync(registerDto);

            if(registerResult.IsSucceed)
                return Ok(registerResult);

            return BadRequest(registerResult);
        }

        // route -> Login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
           var loginResult = await _authService.LoginAsync(loginDto);

            if(loginResult.IsSucceed)
                return Ok(loginResult);

            return Unauthorized(loginResult);
 

        }

        //[HttpPost]
        //[Route("make-user")]
        //public async Task<IActionResult> MakeUser([FromBody] UpdatePermissionDto updatePermissionDto)
        //{
        //    var operationResult = await _authService.MakeUserAsync(updatePermissionDto);

        //    if (operationResult.IsSucceed)
        //        return Ok(operationResult);

        //    return BadRequest(operationResult);
        //}


        // route -> make user-> admin
        [HttpPost]
        [Route("make-admin")]
        public async Task<IActionResult> MakeAdmin([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var operationResult = await _authService.MakeAdminAsync(updatePermissionDto);

            if(operationResult.IsSucceed) 
                return Ok(operationResult);

            return BadRequest(operationResult);
        }


        // route -> make user-> owner

        [HttpPost]
        [Route("make-owner")]
        public async Task<IActionResult> MakeOwner([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var operationResult = await _authService.MakeOwnerAsync(updatePermissionDto);

            if (operationResult.IsSucceed)
                return Ok(operationResult);

            return BadRequest(operationResult);
        }
    }
}


