using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Domain.Models;
using DataHandling;
using System.Net.Http.Headers;
using System.Text;
using Domain.DTOs;

namespace PID_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserOperations _userOperations;
        private readonly IAuthOperations _authOperations;


        public UsersController(IUserOperations userOperations, IAuthOperations authOperations)
        {
            _userOperations = userOperations;
            _authOperations = authOperations;
        }



        // POST: api/Users/CreateUser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
           return await _userOperations.AddNew(user);
        }


        

        // GET: api/GetAllUsers
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
           
            return (await _userOperations.GetAllAsync()).ToList();
        }



        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(string id)
        {
            var user = await _userOperations.GetBasicData(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }




        // PUT: api/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Edit/{id}")]
        public async Task<ActionResult<User>> EditUser(string id, User user)
        {

            return await _userOperations.Edit(id, user);
        }

        

            // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            return await _userOperations.Delete(id);
        }








        /* 
               private bool UserExists(string id)
               {
                   return _context.Users.Any(e => e.SESANum == id);
               }*/

        /*    public bool IsAuthorized()
        {
            var authHeaders = Request.Headers["Authorization"];
            AuthenticationHeaderValue _authValue = AuthenticationHeaderValue.Parse(authHeaders);
            Byte[] credentialBytes = Convert.FromBase64String(_authValue.Parameter);
            //username:password
            string[] credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');

            var username = credentials[0];
            var password = credentials[1];

            return _authOperations.IsValidUser(username, password);
        }*/

        /*
         POST: api/Users/Login
         [HttpPost("Login")]
          public async Task<ActionResult<UserDTO>> LoginUser(UserDTO userDTO)
            {
                return userDTO;
            }*/
    }
}
