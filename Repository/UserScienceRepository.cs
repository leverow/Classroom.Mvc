using Classroom.Mvc.Data;
using Classroom.Mvc.Entities;

namespace Classroom.Mvc.Repository;

public class UserScienceRepository : GenericRepository<UserScience>, IUserScienceRepository
{
    public UserScienceRepository(AppDbContext context) : base(context) { }
}