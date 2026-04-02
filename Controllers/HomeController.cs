using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCodexLms.Data;
using MyCodexLms.Models;
using MyCodexLms.ViewModels;

namespace MyCodexLms.Controllers;

public class HomeController(LmsDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var enrollments = await context.Enrollments
            .Include(enrollment => enrollment.Course)
            .Include(enrollment => enrollment.Student)
            .OrderByDescending(enrollment => enrollment.EnrolledOn)
            .ToListAsync();

        var model = new DashboardViewModel
        {
            CourseCount = await context.Courses.CountAsync(),
            StudentCount = await context.Students.CountAsync(),
            EnrollmentCount = enrollments.Count,
            AverageCompletion = enrollments.Count == 0 ? 0 : enrollments.Average(enrollment => enrollment.CompletionPercentage),
            FeaturedCourses = await context.Courses
                .Include(course => course.Enrollments)
                .OrderBy(course => course.Title)
                .Take(3)
                .ToListAsync(),
            RecentEnrollments = enrollments.Take(5).ToList()
        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
