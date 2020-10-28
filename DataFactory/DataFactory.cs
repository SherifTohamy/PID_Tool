using Data;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataHandling
{
    public class DataFactory<DB,T> : IOperations<T>
        where T : class
        where DB : SWDBContext, new()  // It must be a class (reference type) and must have a public parameter-less default constructor.
    {

        private DB _context = new DB();

        public DB _Data
        {
            get { return _context; }
            set { _context = value; }
        }

        public async Task<T> AddNew(T newRecord)
        {
            _context.Add(newRecord);
            await _context.SaveChangesAsync();
            return newRecord;

            /* T ReturnObj = null;
             _context.Set<T>().Add(Entity);
             if (_context.SaveChanges() > 0)
             {
                 ReturnObj = Entity;
             }
             return ReturnObj;*/
        }

        public Task<T> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

       

        public Task<T> Update(int id, T recordToUpdate)
        {
            throw new NotImplementedException();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        Task<IEnumerable<T>> IOperations<T>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
