using Data;
using DataHandling;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using PIDDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class ProjectManager : IProjectOperations
    {
        private readonly SWDBContext _context;

        public ProjectManager(SWDBContext context)
        {
            _context = context;
        }

        public async Task<Project> AddNew(Project Entity)
        {
            if (ProjectExists(Entity.Id))
            {
                throw new Exception("This Project is already Existed");
            }
            else
            {
                try
                {
                    _context.Projects.Add(Entity);
                    await _context.SaveChangesAsync();
                    return Entity;
                }
                catch (DbUpdateException)
                {
                    throw new Exception("Something goes wrong!");

                }
            }
        }

        public async Task<Project> Delete(string id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                throw new Exception("This user is not existed");
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return project;
        }


        public async Task<Project> Edit(string id, Project recordToUpdate)
        {
            if (id != recordToUpdate.Id)
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
                if (!ProjectExists(id))
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

        public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
        {
            var projects = await _context.Projects.ToListAsync();

            return projects.Select(project => new ProjectDTO
            {
                BudgetHours = project.BudgetHours,
                Id = project.Id,
                ProjectName = project.ProjectName,
                EndDate = project.EndDate,
                StartDate = project.StartDate,
                ClosedBy = project.ClosedBy,
                Comments = project.Comments

            });
        }

        public async Task<ProjectDTO> GetBasicData(string Id)
        {
            var Project = await _context.Projects.Where(x => x.Id == Id)
                 .Select(project => new ProjectDTO
                 {
                     BudgetHours = project.BudgetHours,
                     Id = project.Id,
                     ProjectName = project.ProjectName,
                     EndDate = project.EndDate,
                     StartDate = project.StartDate,
                     ClosedBy = project.ClosedBy,
                     Comments = project.Comments


                 }).FirstOrDefaultAsync();

            return Project;
        }

        
        private bool ProjectExists(string Id)
        {
            return _context.Projects.Any(e => e.Id == Id);
        }
    }
}
