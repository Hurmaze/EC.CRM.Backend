using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories.Specifications
{
    public class GetAllApplicationsSpecification : Specification<UserInfo>
    {
        public GetAllApplicationsSpecification()
        {
            Expression<Func<UserInfo, bool>> criteria =
                   u => u.Role.Name == Roles.Student
                && u.StudentProperties!.State.Name == States.DoingTestTask;

            AddCriteria(criteria)
                .Include(c => c.Credentials)
                .Include(x => x.Locations)
                .Include(x => x.Role)
                .Include(x => x.Skills)
                .Include(x => x.NonProfessionalInterests)
                .Include(x => x.Locations)
                .Include(x => x.StudentProperties)
                .Include(x => x.MentorProperties)
                .Include(x => x.StudyFields)
                .OrderByDescending(x => x.JoinDate);
        }
    }
}
