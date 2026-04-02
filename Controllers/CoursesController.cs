using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCodexLms.Data;
using MyCodexLms.Models;

namespace MyCodexLms.Controllers;

public class CoursesController(LmsDbContext context) : Controller
{
    public async Task<IActionResult> Index(string? searchTerm, string? category)
    {
        var query = context.Courses
            .Include(course => course.Enrollments)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(course =>
                course.Title.Contains(searchTerm) ||
                course.Description.Contains(searchTerm));
        }

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(course => course.Category == category);
        }

        ViewBag.Categories = await context.Courses
            .Select(course => course.Category)
            .Distinct()
            .OrderBy(name => name)
            .ToListAsync();

        ViewBag.SearchTerm = searchTerm;
        ViewBag.SelectedCategory = category;

        return View(await query.OrderBy(course => course.Title).ToListAsync());
    }

    public async Task<IActionResult> Details(int id)
    {
        var course = await context.Courses
            .Include(item => item.Enrollments)
            .ThenInclude(enrollment => enrollment.Student)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (course is null)
        {
            return NotFound();
        }

        return View(course);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Course());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Course course)
    {
        if (!ModelState.IsValid)
        {
            return View(course);
        }

        context.Courses.Add(course);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
