using System.ComponentModel.DataAnnotations;

namespace StudentRosterDbApi.DTOs
{
    public class CourseCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; } = "You're a good student";
    }
}
