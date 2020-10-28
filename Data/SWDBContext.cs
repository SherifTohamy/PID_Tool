using Domain.Models;
using Microsoft.EntityFrameworkCore;
using PIDDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class SWDBContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<RoleSubjectRelation> RoleSubjectRelations{ get; set; }
        public DbSet<UserRoleRelation> UserRoleRelations { get; set; }       
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Role> Roles { get; set; }

        public SWDBContext(DbContextOptions<SWDBContext> options)
            : base(options) { }
    }
}
