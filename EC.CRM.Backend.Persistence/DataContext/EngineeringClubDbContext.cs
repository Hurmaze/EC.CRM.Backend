using EC.CRM.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.DataContext
{
    public class EngineeringClubDbContext : DbContext
    {
        DbSet<Job> Jobs { get; set; }
        DbSet<Mentor> Mentors { get; set; }
        DbSet<Student> Students { get; set; }

        public EngineeringClubDbContext(DbContextOptions<EngineeringClubDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Make constraints
        }
    }
}
