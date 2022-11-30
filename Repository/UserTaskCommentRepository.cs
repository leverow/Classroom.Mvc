using Classroom.Mvc.Data;
using Classroom.Mvc.Entities;

namespace Classroom.Mvc.Repository;

public class UserTaskCommentRepository : GenericRepository<TaskComment>, IUserTaskCommentRepository
{
    public UserTaskCommentRepository(AppDbContext context) : base(context) { }
}