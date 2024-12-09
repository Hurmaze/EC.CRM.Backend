using EC.CRM.Backend.Domain.Repositories;

namespace EC.CRM.Backend.Domain
{
    public interface IUnitOfWork
    {
        ICriteriaRepository CriteriaRepository { get; }
        IJobRepository JobRepository { get; }
        ILocationRepository LocationRepository { get; }
        IMentorRepository MentorRepository { get; }
        INonProfessionalInterestRepository InterestRepository { get; }
        IRoleRepository RoleRepository { get; }
        ISkillRepository SkillRepository { get; }
        IStateRepository StateRepository { get; }
        IStudentRepository StudentRepository { get; }
        IStudyFieldRepository StudyFieldRepository { get; }
        IUserRepository UserRepository { get; }
        Task CommitAsync();
    }
}
