using Classroom.Mvc.Entities;

namespace Classroom.Mvc.Repository;

public interface IUserCourseRepository : IGenericRepository<UserCourse>
{
    Task AddUserCourseAsync(UserCourse entity);
}