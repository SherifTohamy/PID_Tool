using DataHandling;
using Domain.DTOs;
using PIDDb.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class ProjectManager : IProjectOperations
    {
        public Task<Project> AddNew(Project Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Project> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> Edit(string id, Project recordToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDTO> GetBasicData(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
