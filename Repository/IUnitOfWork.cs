namespace Classroom.Mvc.Repository;

public interface IUnitOfWork : IDisposable
{
    IAppTaskRepository Tasks { get; }
    IUserTaskRepository UserTasks { get; }
    IUserTaskCommentRepository UserTasksComments { get; }
    ISchoolRepository Schools { get; }
    ICourseRepository Courses { get; }
    IUserCourseRepository UserCourses { get; }
    int Save();
}