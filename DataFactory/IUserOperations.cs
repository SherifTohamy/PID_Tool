using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataHandling
{
    public interface IUserOperations : IOperations<User>
    {
        Task<UserDTO> GetBasicEmployeeDataAsync(int id);
    }
}
