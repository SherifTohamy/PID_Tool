using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataHandling
{
  public interface IOperations<T> where T : class
    {
        Task<T> AddNew(T Entity);
        Task<T> Delete(int id);
        Task<IEnumerable<T>> GetAll();
        
        Task<T> Update(int id, T recordToUpdate);

    }
}
