using EC.CRM.Backend.Domain;
using EC.CRM.Backend.Domain.Repositories;
using EC.CRM.Backend.Persistence.DataContext;
using EC.CRM.Backend.Persistence.Repositories;

namespace EC.CRM.Backend.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EngineeringClubDbContext dbContext;
        private readonly ICriteriaRepository criteriaRepository;
        private readonly IJobRepository jobRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IMentorRepository mentorRepository;
        private readonly INonProfessionalInterestRepository interestRepository;
        private readonly IRoleRepository roleRepository;
        private readonly ISkillRepository skillRepository;
        private readonly IStateRepository stateRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IStudyFieldRepository studyFieldRepository;
        private readonly IUserRepository userRepository;

        public UnitOfWork(EngineeringClubDbContext dbContext)
        {
            this.dbContext = dbContext;
            criteriaRepository = new CriteriaRepository(dbContext);
            jobRepository = new JobRepository(dbContext);
            locationRepository = new LocationRepository(dbContext);
            mentorRepository = new MentorRepository(dbContext);
            interestRepository = new NonProfessionalInterestsRepository(dbContext);
            roleRepository = new RoleRepository(dbContext);
            skillRepository = new SkillsRepository(dbContext);
            stateRepository = new StateRepository(dbContext);
            studentRepository = new StudentRepository(dbContext);
            studyFieldRepository = new StudyFieldsRepository(dbContext);
            userRepository = new UserRepository(dbContext);
        }

        public ICriteriaRepository CriteriaRepository => criteriaRepository;

        public IJobRepository JobRepository => jobRepository;

        public ILocationRepository LocationRepository => locationRepository;

        public IMentorRepository MentorRepository => mentorRepository;

        public INonProfessionalInterestRepository InterestRepository => interestRepository;

        public IRoleRepository RoleRepository => roleRepository;

        public ISkillRepository SkillRepository => skillRepository;

        public IStateRepository StateRepository => stateRepository;

        public IStudentRepository StudentRepository => studentRepository;

        public IStudyFieldRepository StudyFieldRepository => studyFieldRepository;

        public IUserRepository UserRepository => userRepository;

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
