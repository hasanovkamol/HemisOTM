using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModelEntity.Entity
{
    public class EntityDbContext: IdentityDbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options):base(options)
        {

        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Facultet> Facultets { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Grup> Grups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectBlockType> SubjectBlockTypes { get; set; }
        public DbSet<HarvestPlan> HarvestPlans { get; set; }
        public DbSet<GrupStudentList> GrupStudentLists { get; set; }
    }
}
