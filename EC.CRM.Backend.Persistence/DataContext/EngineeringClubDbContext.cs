using EC.CRM.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.DataContext
{
    public class EngineeringClubDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        public EngineeringClubDbContext(DbContextOptions<EngineeringClubDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userInfo = modelBuilder.Entity<UserInfo>();
            userInfo.HasKey(ui => ui.Uid);
            userInfo.Property(ui => ui.Uid)
                .HasDefaultValue(Guid.NewGuid());
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
            mentor.HasKey(m => m.Id);
            mentor.HasMany(m => m.Students)
                .WithOne(s => s.Mentor)
                .OnDelete(DeleteBehavior.NoAction);
            mentor.HasOne(m => m.UserInfo)
                .WithOne(ui => ui.MentorProperties)
                .HasForeignKey<Mentor>(m => m.UserInfoUid)
                .OnDelete(DeleteBehavior.NoAction);

            var student = modelBuilder.Entity<Student>();
            student.HasKey(s => s.Id);
            student.HasOne(s => s.UserInfo)
                .WithOne(ui => ui.StudentProperties)
                .HasForeignKey<Student>(s => s.UserInfoUid)
                .OnDelete(DeleteBehavior.NoAction);
            student.HasOne(s => s.State)
                .WithMany(s => s.Students);

            var location = modelBuilder.Entity<Location>();
            location.HasKey(l => l.Uid);
            location.Property(ui => ui.Uid)
                .HasDefaultValue(Guid.NewGuid());
            location.HasMany(l => l.Users)
                .WithOne(ui => ui.Location);
            location.Property(l => l.City).HasMaxLength(50);
            location.Property(l => l.Address).HasMaxLength(100);

            var job = modelBuilder.Entity<Job>();
            job.HasKey(j => j.Uid);
            job.Property(ui => ui.Uid)
                .HasDefaultValue(Guid.NewGuid());
            job.Property(j => j.CompanyName).HasMaxLength(100);
            job.Property(j => j.PositionName).HasMaxLength(100);
            job.Property(j => j.Salary)
               .HasPrecision(10, 3)
               .HasColumnType("decimal");

            var state = modelBuilder.Entity<State>();
            state.HasKey(s => s.Uid);
            state.Property(ui => ui.Uid)
                .HasDefaultValue(Guid.NewGuid());
            state.Property(s => s.Name).HasMaxLength(100);

            var role = modelBuilder.Entity<Role>();
            role.HasKey(r => r.Uid);
            role.Property(ui => ui.Uid)
                .HasDefaultValue(Guid.NewGuid());
            role.Property(r => r.Name).HasMaxLength(100);
        }
    }
}
