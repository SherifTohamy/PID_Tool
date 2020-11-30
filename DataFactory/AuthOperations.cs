using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataHandling
{
    public class AuthOperations : IAuthOperations
    {
        private readonly SWDBContext _context;

        public AuthOperations(SWDBContext context)
        {
            _context = context;
        }

        public bool IsAuthorized()
        {
            throw new NotImplementedException();
        }

        public bool IsValidUser(string username, string password)
        {
            return
            _context
            .Users
            .FirstOrDefault(x => x.Password == password && (x.SESANum == username || x.Email == username))
            !=null;
        }

        
    }
}
