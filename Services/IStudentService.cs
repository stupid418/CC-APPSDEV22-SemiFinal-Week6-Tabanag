using System.Collections.Generic;
using System.Threading.Tasks;
using StudentRosterDbApi.Models; // Ensure this namespace matches your DTO folder layout

namespace StudentRosterDbApi.Services
{
    public interface IStudentService
    {
        // Contract signature for fetching the roster
        Task<List<StudentDto>> GetAllStudentsAsync();

        // Contract signature for creating a new student record
        Task<Student> CreateStudentAsync(StudentCreateDto dto);
    }
}
