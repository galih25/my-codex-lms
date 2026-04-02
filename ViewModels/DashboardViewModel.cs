using MyCodexLms.Models;

namespace MyCodexLms.ViewModels;

public class DashboardViewModel
{
    public int CourseCount { get; set; }
    public int StudentCount { get; set; }
    public int EnrollmentCount { get; set; }
    public double AverageCompletion { get; set; }
    public IReadOnlyList<Course> FeaturedCourses { get; set; } = Array.Empty<Course>();
    public IReadOnlyList<Enrollment> RecentEnrollments { get; set; } = Array.Empty<Enrollment>();
}
