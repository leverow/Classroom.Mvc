using Classroom.Mvc;
using Classroom.Mvc.Data;
using Classroom.Mvc.Entities;
using Classroom.Mvc.Middlewares;
using Classroom.Mvc.Repository;
using Classroom.Mvc.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TelegramSink;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLazyLoadingProxies()
    .UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, AppUserRole>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireUppercase = false;
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("WebsiteOptions"));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ISchoolService, SchoolService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<IAppTaskService, AppTaskService>();

builder.Services.AddScoped<IUserManagementService, UserManagementService>();

var logger = new LoggerConfiguration()
    .WriteTo.File(
        path: "Exceptions.log",
        fileSizeLimitBytes: 20,
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
    .WriteTo.TeleSink("5754291260:AAEPhrb9cWA6p1QKHun4vfVbHjQPdJZEDX8", "-1001732303109", minimumLevel: Serilog.Events.LogEventLevel.Error)
    .CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.AddCors(options => {
    options.AddPolicy("Production", cors =>
    {
        cors.WithOrigins("http://hello.com", "http://www.test.com");
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseCors("Production");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
