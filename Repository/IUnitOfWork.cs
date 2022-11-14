namespace Classroom.Mvc.Repository;

public interface IUnitOfWork : IDisposable
{
    IAppTaskRepository Tasks { get; }
    IUserTaskRepository UserTasks { get; }
    IUserTaskCommentRepository UserTasksComments { get; }
    ISchoolRepository Schools { get; }
    IScienceRepository Sciences { get; }
    IUserScienceRepository UserSciences { get; }
    int Save();
}