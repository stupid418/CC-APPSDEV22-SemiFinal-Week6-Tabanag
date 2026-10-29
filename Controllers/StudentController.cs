using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentRosterDbApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Requires valid JWT for ALL methods in this controller
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDto dto)
        {
            // Note: [ApiController] automatically handles Data Annotation validation
            // and returns 400 Bad Request if it fails.
            var createdStudent = await _studentService.CreateStudentAsync(dto);
            return CreatedAtAction(nameof(GetAllStudents), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // ONLY users with "Admin" role can delete
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            // (Implement delete logic in service for Attempt 2)
            return NoContent();
        }
    }
}
