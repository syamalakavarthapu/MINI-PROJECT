using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MINI_PROJECT.Context;
// using MINI_PROJECT.Helper;
using MINI_PROJECT.Models;

namespace MINI_PROJECT.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly AppDbContext _authContext;
        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }

        [HttpPost("authenticate")]

        public async Task<IActionResult> Authenticate([FromBody] User userObj) 
        {
           if(userObj == null)
           return BadRequest();

           var user = await _authContext.Mini_Users
           .FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.Password == userObj.Password);
           if(user ==null)
           return NotFound(new {Massage = "User Not Found!"});
             return Ok(new
            {
                Message = " Login Success!"
            });

        }

        [HttpPost("register")]
        public async Task<IActionResult>RegisterValue([FromBody] User userObj)
        {
            if(userObj==null)
            return BadRequest();
            
            // userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            // userObj.Role = "User";
            // userObj.Token = "";
            await _authContext.Mini_Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = " User Registered!"
            });

        }
    }
}