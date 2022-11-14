using Classroom.Mvc.Data;
using Classroom.Mvc.Entities;

namespace Classroom.Mvc.Repository;

public class AppTaskRepository : GenericRepository<AppTask>, IAppTaskRepository
{
    public AppTaskRepository(AppDbContext context) : base(context) { }
}