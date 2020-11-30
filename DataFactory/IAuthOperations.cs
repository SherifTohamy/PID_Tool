using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandling
{
   public interface IAuthOperations
    {
       public bool IsValidUser(string username, string password);
       public bool IsAuthorized();
    }
}
