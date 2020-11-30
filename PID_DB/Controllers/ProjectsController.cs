using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using PIDDb.Models;
using DataHandling;
using Domain.DTOs;

namespace PID_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {


        private readonly IProjectOperations _projectOperations;
        private readonly IAuthOperations _authOperations;


        public ProjectsController(IProjectOperations projectOperations, IAuthOperations authOperations)
        {
            _projectOperations = projectOperations;
            _authOperations = authOperations;
        }


        // GET: api/GetAllProjects
        [HttpGet("GetAllProjects")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
        {

            return (await _projectOperations.GetAllAsync()).ToList();
        }



        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(string id)
        {
            var project = await _projectOperations.GetBasicData(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }


        // PUT: api/Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Edit/{id}")]
        public async Task<ActionResult<Project>> EditUser(string id, Project project)
        {

            return await _projectOperations.Edit(id, project);
        }


        // POST: api/Projects
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("CreateProject")]
        public async Task<ActionResult<Project>> PostUser(Project project)
        {
            return await _projectOperations.AddNew(project);
        }


        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteUser(string id)
        {
            return await _projectOperations.Delete(id);
        }

    }
}
