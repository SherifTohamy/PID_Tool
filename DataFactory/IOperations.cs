using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataHandling
{
  public interface IOperations<T, T_DTO> 
        where T : class,new()
        where T_DTO : class, new()
    {
        Task<T> AddNew(T Entity);
        Task<T> Delete(string id);
        Task<IEnumerable<T_DTO>> GetAllAsync();
        Task<T_DTO> GetBasicData(string Id);
        Task<T> Edit(string id, T recordToUpdate);
    }
}
