using API.Helpers;
using Entity.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var services = builder.Services;
        // Add services to the container.


        ConfigurationServices(services);
        builder.Services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.

        Configure(app);

        app.Run();
    }

    private static void ConfigurationServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAuthorization();
        services.AddAuthentication();

        services.AddAutoMapper(typeof(MappingProfiles));

        services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost3000", builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
    private static void Configure(WebApplication app)
    {
        ConfigureMiddleware(app);
        RunInitialisers(app);
    }

    private static void ConfigureMiddleware(WebApplication app)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowLocalhost3000");
        app.UseHttpsRedirection();

        app.MapControllers();

    }

    private static async void RunInitialisers(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();
        try
        {
            var context = services.GetRequiredService<StoreDbContext>();
            await context.Database.MigrateAsync();
            await StoreContextSeed.SeedAsync(context, logger);
        }
        catch (Exception ex)
        {

            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}