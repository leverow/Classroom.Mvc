using Classroom.Mvc.Data;
using Classroom.Mvc.Entities;

namespace Classroom.Mvc.Repository;

public class UserTaskRepository : GenericRepository<UserTask>, IUserTaskRepository
{
    public UserTaskRepository(AppDbContext context) : base(context) { }
}