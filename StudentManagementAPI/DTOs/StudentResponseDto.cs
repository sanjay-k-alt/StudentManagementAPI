
namespace StudentManagementAPI.DTOs
{
    public class StudentResponseDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Course { get; set; } = string.Empty;

        public int Age { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
