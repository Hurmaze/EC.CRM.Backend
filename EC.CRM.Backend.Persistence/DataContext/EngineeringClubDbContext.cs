using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Entities.TOPSIS;
using EC.CRM.Backend.Persistence.DataContext.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EC.CRM.Backend.Persistence.DataContext
{
    public class EngineeringClubDbContext : DbContext
    {
        private readonly DbContextSeedingOptions seedingOptions;
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<MentorValuation> MentorValuations { get; set; }

        public EngineeringClubDbContext(DbContextOptions<EngineeringClubDbContext> dbContextOptions, IOptions<DbContextSeedingOptions>? seedingOptions = null) : base(dbContextOptions)
        {
            this.seedingOptions = seedingOptions is null
                ? new DbContextSeedingOptions() { SeedBasicData = false, SeedTestData = false }
                : seedingOptions.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region configuration
            var userInfo = modelBuilder.Entity<UserInfo>();
            userInfo.HasKey(ui => ui.Uid);
            userInfo.Property(ui => ui.Uid)
                .HasDefaultValueSql("newsequentialid()");
            userInfo.HasMany(ui => ui.Jobs)
                .WithOne(j => j.UserInfo);
            userInfo.HasOne(ui => ui.Role)
                .WithMany(r => r.UserInfos);
            userInfo.HasOne(ui => ui.Credentials)
                .WithOne(c => c.User)
                .HasForeignKey<Credentials>(c => c.UserInfoUid)
                .OnDelete(DeleteBehavior.Cascade);
            userInfo.HasMany(ui => ui.NonProfessionalInterests)
                .WithMany(npi => npi.Users);
            userInfo.HasMany(ui => ui.Skills)
                .WithMany(npi => npi.Users);
            userInfo.HasMany(ui => ui.StudyFields)
                .WithMany(npi => npi.Users);
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
                .HasDefaultValueSql("newsequentialid()");
            location.HasMany(l => l.Users)
                .WithMany(ui => ui.Locations);
            location.Property(l => l.City).HasMaxLength(50);
            location.Property(l => l.Address).HasMaxLength(100);

            var job = modelBuilder.Entity<Job>();
            job.HasKey(j => j.Uid);
            job.Property(ui => ui.Uid)
                .HasDefaultValueSql("newsequentialid()");
            job.Property(j => j.CompanyName).HasMaxLength(100);
            job.Property(j => j.PositionName).HasMaxLength(100);
            job.Property(j => j.Salary)
               .HasPrecision(10, 3)
               .HasColumnType("decimal");

            var state = modelBuilder.Entity<State>();
            state.HasKey(s => s.Uid);
            state.Property(ui => ui.Uid)
                .HasDefaultValueSql("newsequentialid()");
            state.Property(s => s.Name).HasMaxLength(100);

            var role = modelBuilder.Entity<Role>();
            role.HasKey(r => r.Uid);
            role.Property(ui => ui.Uid)
                .HasDefaultValueSql("newsequentialid()");
            role.Property(r => r.Name).HasMaxLength(100);

            var credentials = modelBuilder.Entity<Credentials>();
            credentials.HasKey(c => c.UserInfoUid);
            credentials.Property(p => p.PasswordSalt).IsRequired();
            credentials.Property(p => p.PasswordHash).IsRequired();

            var skill = modelBuilder.Entity<Skill>();
            skill.HasKey(s => s.Uid);
            skill.Property(s => s.Uid)
                .HasDefaultValueSql("newsequentialid()");
            skill.Property(p => p.Name).HasMaxLength(100).IsRequired();

            var interest = modelBuilder.Entity<NonProfessionalInterest>();
            interest.HasKey(i => i.Uid);
            interest.Property(i => i.Uid)
                .HasDefaultValueSql("newsequentialid()");
            interest.Property(p => p.Name).HasMaxLength(100).IsRequired();

            var studyfield = modelBuilder.Entity<StudyField>();
            studyfield.HasKey(s => s.Uid);
            studyfield.Property(s => s.Uid)
                .HasDefaultValueSql("newsequentialid()");
            studyfield.Property(p => p.Name).HasMaxLength(100).IsRequired();

            var criteria = modelBuilder.Entity<Criteria>();
            criteria.HasKey(c => c.Name);
            criteria.Property(c => c.Name)
                .HasMaxLength(100);

            var mentorValuation = modelBuilder.Entity<MentorValuation>();
            mentorValuation.HasNoKey();
            #endregion

            #region data seeding

            SeedData(modelBuilder);

            #endregion
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            if (seedingOptions.SeedBasicData)
            {
                var dBseeder = new DatabaseSeeder();

                modelBuilder.Entity<Role>().HasData(dBseeder.Roles);
                modelBuilder.Entity<State>().HasData(dBseeder.States);
                modelBuilder.Entity<Location>().HasData(dBseeder.Locations);
                modelBuilder.Entity<NonProfessionalInterest>().HasData(dBseeder.NonProfessionalInterests);
                modelBuilder.Entity<Skill>().HasData(dBseeder.Skills);
                modelBuilder.Entity<StudyField>().HasData(dBseeder.StudyFields);

                if (seedingOptions.SeedTestData)
                {
                    modelBuilder.Entity<UserInfo>().HasData(dBseeder.UserInfos);
                    //modelBuilder.Entity<Credentials>().HasData(dBseeder.Credentials);
                    modelBuilder.Entity<Mentor>().HasData(dBseeder.Mentors);
                    modelBuilder.Entity<Student>().HasData(dBseeder.Students);
                }
            }
        }
    }
}
