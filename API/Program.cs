using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication();

        builder.Services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.

        Configure(app);

        app.Run();
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