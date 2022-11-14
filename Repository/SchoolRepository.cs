using Classroom.Mvc.Data;
using Classroom.Mvc.Entities;

namespace Classroom.Mvc.Repository;

public class SchoolRepository : GenericRepository<School>, ISchoolRepository
{
    public SchoolRepository(AppDbContext context) : base(context) { }
}