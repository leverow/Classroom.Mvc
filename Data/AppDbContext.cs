using Classroom.Mvc.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Classroom.Mvc.Data;

public class AppDbContext : IdentityDbContext<AppUser, AppUserRole, Guid>
{
    public DbSet<School>? Schools { get; set; }
    public DbSet<Science>? Sciences { get; set; }
    public DbSet<UserScience>? UserSciences { get; set; }
    public DbSet<AppTask>? Tasks { get; set; }
    public DbSet<UserTask>? UserTasks { get; set; }
    public DbSet<UserTaskComment>? UserTaskComments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        List<string> roleNames = new() {"Admin","Teacher","Student"};
        
        foreach(var roleName in roleNames)
            builder.Entity<AppUserRole>().HasData(new AppUserRole()
            {
                Id = Guid.NewGuid(),
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            });
    }
}