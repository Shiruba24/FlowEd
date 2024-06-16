using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entity;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class StoreContextSeed
    {
        public static async Task SeedDataIfEmpty<T>(
            DbSet<T> dbSet,
            StoreDbContext context,
            string jsonFilePath
        )
            where T : class
        {
            if (!dbSet.Any())
            { // Если коллекция пуста
                var jsonData = File.ReadAllText(jsonFilePath);
                var items = JsonSerializer.Deserialize<List<T>>(jsonData);

                if (items != null)
                {
                    foreach (var item in items)
                    {
                        dbSet.Add(item); // Добавляем в коллекцию
                    }

                    await context.SaveChangesAsync(); // Сохраняем изменения
                }
            }
        }

        public static async Task SeedAsync(StoreDbContext context, ILogger logger, UserManager<User> userManager)
        {
            try
            {
                if (!userManager.Users.Any())
                {
                    var student = new User
                    {
                        UserName = "student",
                        Email = "student@test.com",
                    };

                    await userManager.CreateAsync(student, "Password@123");
                    await userManager.AddToRoleAsync(student, "Student");

                    var instructor = new User
                    {
                        UserName = "instructor",
                        Email = "instructor@test.com",
                    };

                    await userManager.CreateAsync(instructor, "Password@123");
                    await userManager.AddToRolesAsync(instructor, new[] { "Instructor", "Student" });
                }
                await SeedDataIfEmpty(
                    context.Categories,
                    context,
                    "../Infrastructure/SeedData/categories.json"
                );
                await SeedDataIfEmpty(
                    context.Courses,
                    context,
                    "../Infrastructure/SeedData/courses.json"
                );

                await SeedDataIfEmpty(
                    context.Learnings,
                    context,
                    "../Infrastructure/SeedData/learnings.json"
                );
                await SeedDataIfEmpty(
                    context.Requirements,
                    context,
                    "../Infrastructure/SeedData/requirements.json"
                );


                //if (!context.Categories.Any())
                //{
                //    var categoryData = File.ReadAllText("../Infrastructure/SeedData/categories.json");
                //    var category = JsonSerializer.Deserialize<List<Category>>(categoryData);

                //    foreach (var item in category)
                //    {
                //        context.Categories.Add(item);
                //    }

                //    await context.SaveChangesAsync();
                //}
                //if (!context.Courses.Any())
                //{
                //    var courseData = File.ReadAllText("../Infrastructure/SeedData/courses.json");
                //    var courses = JsonSerializer.Deserialize<List<Course>>(courseData);

                //    foreach (var course in courses)
                //    {
                //        context.Courses.Add(course);
                //    }

                //    await context.SaveChangesAsync();
                //}
                //if (!context.Learnings.Any())
                //{
                //    var learningData = File.ReadAllText("../Infrastructure/SeedData/learnings.json");
                //    var learnings = JsonSerializer.Deserialize<List<Learning>>(learningData);

                //    foreach (var item in learnings)
                //    {
                //        context.Learnings.Add(item);
                //    }

                //    await context.SaveChangesAsync();
                //}
                //if (!context.Requirements.Any())
                //{
                //    var requirementsData = File.ReadAllText("../Infrastructure/SeedData/requirements.json");
                //    var requirements = JsonSerializer.Deserialize<List<Requirement>>(requirementsData);

                //    foreach (var item in requirements)
                //    {
                //        context.Requirements.Add(item);
                //    }

                //    await context.SaveChangesAsync();
                //}
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
