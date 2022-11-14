using Classroom.Mvc.Data;
using Classroom.Mvc.Entities;

namespace Classroom.Mvc.Repository;

public class ScienceRepository : GenericRepository<Science>, IScienceRepository
{
    public ScienceRepository(AppDbContext context) : base(context) { }
}