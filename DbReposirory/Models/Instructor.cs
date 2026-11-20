using System.ComponentModel.DataAnnotations;

namespace DbReposirory.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "{0} is required.")]
        [MinLength (8, ErrorMessage = "{0} must be at least {1} characters long.")]
        public string InstructorCode { get; set; }

        [Required (ErrorMessage = "{0} is required.")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string FullName { get; set; }

        [Required (ErrorMessage = "{0} is required.")]
        [EmailAddress (ErrorMessage = "Invalid {0} format.")]
        public string Email { get; set; }

        [Range (0, 40, ErrorMessage = "{0} must be between {2} and {1}.")]
        public int YearsOfExperience { get; set; }

        [StringLength (200, MinimumLength = 50, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string? Bio { get; set; }
    }
}
