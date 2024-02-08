using EC.CRM.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.DataContext
{
    public class EngineeringClubDbContext : DbContext
    {
        DbSet<Job> Jobs { get; set; }
        DbSet<Mentor> Mentors { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<State> States { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserInfo> UserInfos { get; set; }

        public EngineeringClubDbContext(DbContextOptions<EngineeringClubDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userInfo = modelBuilder.Entity<UserInfo>();
            userInfo.HasKey(ui => ui.Uid);
            userInfo.HasMany(ui => ui.Jobs)
                .WithOne(j => j.UserInfo);
            userInfo.HasOne(ui => ui.Role)
                .WithMany(r => r.UserInfos);
            userInfo.Property(ui => ui.Description).HasMaxLength(500);
            userInfo.Property(ui => ui.PhoneNumber).HasMaxLength(20);
            userInfo.Property(ui => ui.Name).HasMaxLength(100);
            userInfo.Property(ui => ui.Email).HasMaxLength(100);
            userInfo.Property(ui => ui.Paid)
                .HasPrecision(10, 3)
                .HasColumnType("decimal");
            userInfo.Property(ui => ui.CurentSalary)
               .HasPrecision(10, 3)
               .HasColumnType("decimal");

            var mentor = modelBuilder.Entity<Mentor>();
            mentor.HasKey(m => m.Uid);
            mentor.HasMany(m => m.Students)
                .WithOne(s => s.Mentor)
                .OnDelete(DeleteBehavior.NoAction);
            mentor.HasOne(m => m.UserInfo)
                .WithOne(ui => ui.MentorProperties)
                .HasForeignKey<Mentor>(m => m.UserInfoUid)
                .OnDelete(DeleteBehavior.NoAction);

            var student = modelBuilder.Entity<Student>();
            student.HasKey(s => s.Uid);
            student.HasOne(s => s.UserInfo)
                .WithOne(ui => ui.StudentProperties)
                .HasForeignKey<Student>(s => s.UserInfoUid)
                .OnDelete(DeleteBehavior.NoAction);
            student.HasOne(s => s.State)
                .WithMany(s => s.Students);

            var location = modelBuilder.Entity<Location>();
            location.HasKey(l => l.Uid);
            location.HasMany(l => l.Users)
                .WithOne(ui => ui.Location);
            location.Property(l => l.City).HasMaxLength(50);
            location.Property(l => l.Address).HasMaxLength(100);

            var job = modelBuilder.Entity<Job>();
            job.HasKey(j => j.Uid);
            job.Property(j => j.CompanyName).HasMaxLength(100);
            job.Property(j => j.PositionName).HasMaxLength(100);
            job.Property(j => j.Salary)
               .HasPrecision(10, 3)
               .HasColumnType("decimal");

            var state = modelBuilder.Entity<State>();
            state.HasKey(s => s.Uid);
            state.Property(s => s.Name).HasMaxLength(100);

            var role = modelBuilder.Entity<Role>();
            role.HasKey(r => r.Uid);
            role.Property(r => r.Name).HasMaxLength(100);
        }
    }
}
