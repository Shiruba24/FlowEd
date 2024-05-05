using Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context, ILogger logger)
        {

            try
            {
                if (!context.Courses.Any())
                {
                    var courseData = File.ReadAllText("../Infrastructure/SeedData/courses.json");
                    var courses = JsonSerializer.Deserialize<List<Course>>(courseData);

                    foreach (var course in courses)
                    {
                        context.Courses.Add(course);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

            }
        }
    }
}
