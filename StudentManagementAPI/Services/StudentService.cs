
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.DTOs;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all students
        public async Task<List<StudentResponseDto>> GetAllAsync()
        {
            return await _context.Students
                .AsNoTracking()
                .OrderBy(s => s.Id)
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Email = s.Email,
                    Course = s.Course,
                    Age = s.Age,
                    CreatedAt = s.CreatedAt
                })
                .ToListAsync();
        }

        // Get student by ID
        public async Task<StudentResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Students
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Email = s.Email,
                    Course = s.Course,
                    Age = s.Age,
                    CreatedAt = s.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        // Add student
        public async Task<StudentResponseDto> CreateAsync(
            CreateStudentDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Course = dto.Course,
                Age = dto.Age
            };

            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return new StudentResponseDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                Course = student.Course,
                Age = student.Age,
                CreatedAt = student.CreatedAt
            };
        }

        // Update student
        public async Task<bool> UpdateAsync(
            int id, UpdateStudentDto dto)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return false;

            student.FullName = dto.FullName;
            student.Email = dto.Email;
            student.Course = dto.Course;
            student.Age = dto.Age;

            await _context.SaveChangesAsync();

            return true;
        }

        // Delete student
        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return false;

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
