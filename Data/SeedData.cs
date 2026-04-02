using Microsoft.EntityFrameworkCore;
using MyCodexLms.Models;

namespace MyCodexLms.Data;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        await using var context = serviceProvider.GetRequiredService<LmsDbContext>();
        await context.Database.EnsureCreatedAsync();

        if (await context.Courses.AnyAsync())
        {
            return;
        }

        var courses = new List<Course>
        {
            new()
            {
                Title = "ASP.NET MVC Fundamentals",
                Description = "Build maintainable web applications with controllers, Razor views, routing, and validation.",
                DurationInWeeks = 6,
                MaxStudents = 30,
                Category = "Web Development"
            },
            new()
            {
                Title = "SQL Server for Application Developers",
                Description = "Design relational schemas, optimize queries, and work with SQL Server in business applications.",
                DurationInWeeks = 5,
                MaxStudents = 25,
                Category = "Databases"
            },
            new()
            {
                Title = "Entity Framework Core in Practice",
                Description = "Use EF Core with SQL Server for migrations, querying, and transactional data access.",
                DurationInWeeks = 4,
                MaxStudents = 20,
                Category = "Backend"
            }
        };

        var students = new List<Student>
        {
            new() { FirstName = "Ava", LastName = "Patel", Email = "ava.patel@example.com" },
            new() { FirstName = "Noah", LastName = "Johnson", Email = "noah.johnson@example.com" },
            new() { FirstName = "Mia", LastName = "Garcia", Email = "mia.garcia@example.com" }
        };

        await context.Courses.AddRangeAsync(courses);
        await context.Students.AddRangeAsync(students);
        await context.SaveChangesAsync();

        var enrollments = new List<Enrollment>
        {
            new() { CourseId = courses[0].Id, StudentId = students[0].Id, CompletionPercentage = 60 },
            new() { CourseId = courses[1].Id, StudentId = students[0].Id, CompletionPercentage = 25 },
            new() { CourseId = courses[0].Id, StudentId = students[1].Id, CompletionPercentage = 100 },
            new() { CourseId = courses[2].Id, StudentId = students[2].Id, CompletionPercentage = 40 }
        };

        await context.Enrollments.AddRangeAsync(enrollments);
        await context.SaveChangesAsync();
    }
}
