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
          
              if (UserExists(Entity.SESANum))
              {
                  throw new Exception("This Sesa Number is already Existed");
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

            /* public async Task<User> AddNewUserAsync(User newRecord)
             {



                 }
             }*/
        }
            public Task<User> Delete(int id)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<User> GetAll()
            {
                throw new NotImplementedException();
            }

        public Task<UserDTO> GetBasicEmployeeDataAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(int id, User recordToUpdate)
            {
                throw new NotImplementedException();
            }

        Task<IEnumerable<User>> IOperations<User>.GetAll()
        {
            throw new NotImplementedException();
        }

        private bool UserExists(string id)
            {
                return _context.Users.Any(e => e.SESANum == id);
            }
        

    }
    }

