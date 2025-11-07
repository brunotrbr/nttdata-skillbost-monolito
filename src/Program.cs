using src.Repository;
using src.Repository.Interface;
using src.Service;
using src.Service.Interface;
using src.Configs;

namespace src;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var section = builder.Configuration.GetSection("ConnectionStrings");
        builder.Services.Configure<PostgresConfig>(section);
    //     builder.Services.Configure<PostgresConfig>(
    // builder.Configuration.GetSection("PostgresConfig"));

        builder.Services.AddScoped<ICourseActivityService, CourseActivityService>();
        builder.Services.AddScoped<ICoursesService, CoursesService>();
        builder.Services.AddScoped<IProfileService, ProfileService>();

        builder.Services.AddScoped<ICourseActivityRepository, CourseActivityRepository>();
        builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
        builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

        builder.Services.AddControllers();

        var app = builder.Build();

        // app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}