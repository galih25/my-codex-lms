using System.ComponentModel.DataAnnotations;

namespace MyCodexLms.Models;

public class Course
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required, StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Range(1, 52)]
    [Display(Name = "Duration (weeks)")]
    public int DurationInWeeks { get; set; }

    [Range(0, 9999)]
    [Display(Name = "Enrollment cap")]
    public int MaxStudents { get; set; }

    [Required, StringLength(80)]
    public string Category { get; set; } = string.Empty;

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public int RemainingSeats => MaxStudents - Enrollments.Count;
}
