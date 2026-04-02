using System.ComponentModel.DataAnnotations;

namespace MyCodexLms.Models;

public class Enrollment
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Student")]
    public int StudentId { get; set; }

    public Student? Student { get; set; }

    [Required]
    [Display(Name = "Course")]
    public int CourseId { get; set; }

    public Course? Course { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Enrolled on")]
    public DateTime EnrolledOn { get; set; } = DateTime.UtcNow.Date;

    [Range(0, 100)]
    [Display(Name = "Completion %")]
    public int CompletionPercentage { get; set; }

    public bool IsCompleted => CompletionPercentage >= 100;
}
