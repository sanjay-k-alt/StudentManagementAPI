
using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.DTOs
{
    public class UpdateStudentDto
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Course { get; set; } = string.Empty;

        [Range(1, 100)]
        public int Age { get; set; }
    }
}
