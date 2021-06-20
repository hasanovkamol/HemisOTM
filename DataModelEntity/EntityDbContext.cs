using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataModelEntity.Entity
{
    public class EntityDbContext: IdentityDbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options):base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SubjectTraingPlan>()
              .HasOne(x => x.Subject)
              .WithMany(x => x.Subjects)
              .HasForeignKey(x => x.SubjectId)
              .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<SubjectTraingPlan>()
               .HasOne(x => x.HarvestPlan)
               .WithMany(x => x.Subjects)
               .HasForeignKey(x => x.HardvesPlanId)
               .OnDelete(DeleteBehavior.ClientSetNull);

           
            builder.Entity<SubjectTraingPlan>().ToTable("SubjectTraingPlans");
            base.OnModelCreating(builder);
        }
        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    foreach (var entry in ChangeTracker.Entries<Subject>())
        //    {
        //        if (this.Subjects.Find(entry.Entity.SubjectId) != null)
        //            entry.State = EntityState.Detached;
        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Facultet> Facultets { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Grup> Grups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectBlockType> SubjectBlockTypes { get; set; }
        public DbSet<HarvestPlan> HarvestPlans { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
