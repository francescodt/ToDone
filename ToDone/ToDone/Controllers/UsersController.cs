﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using ToDone.Models;
using ToDone.Models.DTOs;

namespace ToDone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ToDoUser> userManager;

        private readonly IConfiguration configuration;

        public UsersController(UserManager<ToDoUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterData register)
        {
            var user = new ToDoUser
            {
                Email = register.Email,
                UserName = register.Email,

                FirstName = register.FirstName,
                LastName = register.LastName,
            };

            var result = await userManager.CreateAsync(user, register.Password);

            if(!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok(new UserWithToken
            {
                UserId = user.Id,
                Token = CreateToken(user),

            }); 
        }

        private string CreateToken(ToDoUser user)
        {
            var secret = configuration["JWT:Secret"];

            var secretBytes = Encoding.UTF8.GetBytes(secret);

            var signingKey = new SymmetricSecurityKey(secretBytes);

            var tokenClaims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim ("UserId", user.Id),
                new Claim ("FullName", $"{user.FirstName} {user.LastName}")

            };

            var token = new JwtSecurityToken(
                claims: tokenClaims,
                expires: DateTime.UtcNow.AddHours(6),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)

                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginData login)
        {
            var user = await userManager.FindByNameAsync(login.UserName);
            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, login.Password);
                if (result)
                {
                    return Ok(new UserWithToken
                    {
                        UserId = user.Id,
                        Token = CreateToken(user),
                    });
                }
                await userManager.AccessFailedAsync(user);
            }

            return Unauthorized();
                
        }

        [Authorize]
        [HttpGet("Self")]
        public async Task<IActionResult> Self()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var userClaim = identity.FindFirst("UserId");
                var userId = userClaim.Value;
                var user = await userManager.FindByIdAsync(userId);

                if (user == null)
                    return Unauthorized();

                return Ok(new
                {
                    UserId = user.Id,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                });
            }

            return Unauthorized();
        }
    }
}