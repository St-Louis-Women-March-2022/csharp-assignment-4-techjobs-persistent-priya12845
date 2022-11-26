using TechJobsPersistentAutograded.Models;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistentAutograded.Data
{
    //This class for the database connection. For the migration to create the table in the database and the CRUD operations
    public class JobDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }

        public JobDbContext(DbContextOptions<JobDbContext> options)
            : base(options)
        {
        }

        //This method for the compound primary key. This is the place you put the configuration information about your models.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobSkill>()
                .HasKey(j => new { j.JobId, j.SkillId });
        }
    }
}

