using Data;
using DataHandling;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Managers
{
    public class UserManager : IUserOperations
    {
        private readonly SWDBContext _context;

        public UserManager(SWDBContext context)
        {
            _context = context;
        }

        public async Task<User> AddNew(User Entity)
        {

            if (UserExists(Entity.SESANum, Entity.Email))
            {
                throw new Exception("This username is already Existed");
            }
            else
            {
                try
                {
                    _context.Users.Add(Entity);
                    await _context.SaveChangesAsync();
                    return Entity;
                }
                catch (DbUpdateException)
                {
                    throw new Exception("Something goes wrong!");

                }
            }


        }
        public async Task<User> Delete(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("This user is not existed");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users.Select(user => new UserDTO
            {
                Email = user.Email,
                Name = user.Name

            });
        }

        public async Task<UserDTO> GetBasicData(string id)
        {
            var mappedUser = await _context.Users.Where(x => x.SESANum == id)
                 .Select(user => new UserDTO
                 {
                     Name = user.Name,
                     Email = user.Email,
                     Enabled = user.IsEnabled

                 }).FirstOrDefaultAsync();

            return mappedUser;

        }

        public async Task<User> Edit(string id, User recordToUpdate)
        {
            if (id != recordToUpdate.SESANum)
            {
                throw new Exception("BadRequest!");
            }
            _context.Entry(recordToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists_(id))
                {
                    throw new Exception("User not found!");
                }
                else
                {
                    throw;
                }
            }
            return recordToUpdate;
        }



        private bool UserExists(string sesa, string email)
        {
            return _context.Users.Any(e => e.SESANum == sesa || e.Email == email);
        }
        private bool UserExists_(string sesa)
        {
            return _context.Users.Any(e => e.SESANum == sesa);
        }

       
    }
}

