using Classroom.Mvc.Data;

namespace Classroom.Mvc.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IAppTaskRepository Tasks { get; }
    public IUserTaskRepository UserTasks { get; }
    public IUserTaskCommentRepository UserTasksComments { get; }
    public ISchoolRepository Schools { get; }
    public IScienceRepository Sciences { get; }
    public IUserScienceRepository UserSciences { get; }
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Tasks = new AppTaskRepository(context);
        UserTasks = new UserTaskRepository(context);
        UserTasksComments = new UserTaskCommentRepository(context);
        Schools = new SchoolRepository(context);
        Sciences = new ScienceRepository(context);
        UserSciences = new UserScienceRepository(context);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public int Save()
        => _context.SaveChanges();
}