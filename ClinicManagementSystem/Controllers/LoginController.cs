using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.Logins;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogin _login;
        public LoginController(ILogin login,IConfiguration configuration)
        {
            _login = login;
            _config = configuration;
        }

        #region Add a Login
        [HttpPost]
        public async Task<IActionResult> AddLogin([FromBody] Login login)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var LoginID = await _login.AddLogin(login);
                    if (LoginID > 0)
                    {
                        return Ok(LoginID);
                    }
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Login 
        [HttpGet("/{username}/{password}")]
        public async Task<ActionResult> GetUserByIdPass(string username, string password)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //signing credential
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            //generate token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);
            var response = Ok(new { token = ' ', empName = ' ', empPassword = ' ' });


            if (ModelState.IsValid)
            {
                try
                {
                    var tokens = new JwtSecurityTokenHandler().WriteToken(token);

                    try
                    {
                        if (_login != null)
                        {

                            var emp = await _login.LoginUser(username, password);
                            if (emp != null)
                            {
                                response = Ok(new { token = tokens, LoginId = emp.LoginId, StaffId = emp.StaffId,Firstname=emp.Username,RoleId=emp.RoleId });
                                return response;
                            }
                            else
                            {
                                return response = Ok(new { token = ' ', LoginId = "null", StaffId = ' ' });
                            }
                        }
                        else
                        {
                            return response = Ok(new { token = ' ', LoginId = "null", StaffId = ' ' });
                        }
                    }
                    catch (NullReferenceException)
                    {
                        return response = Ok(new { token = ' ', LoginId = "null", StaffId = ' ' });
                    }
                }
                catch (NullReferenceException)
                {
                    return response = Ok(new { token = ' ', LoginId = "null", StaffId = ' ' });
                }
            }
            return response;

        }
        #endregion

        #region Update Login
        [HttpPut]
        public async Task<IActionResult> UpdateLogin([FromBody] Login login)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _login.UpdateLogin(login);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion


    }
}
