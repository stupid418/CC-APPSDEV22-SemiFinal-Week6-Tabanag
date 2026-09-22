using Microsoft.AspNetCore.Mvc;
using StudentRosterApi.Models;

namespace StudentRosterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  
    public class StudentController : ControllerBase
    {
        // Mock database - fixed duplicate ID (Id = 2)
        private static readonly List<Student> students = new List<Student>
        {
            new Student { Id = 1, FirstName = "Gean", LastName = "Tabanag", Course = "BSCS", YearLevel = 3 },
            new Student { Id = 2, FirstName = "Gian Carlo", LastName = "Tabanag", Course = "BSIT", YearLevel = 2 },
        };

        // GET: api/student
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(students);
        }

        // GET: api/student/5
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(new { message = $"Student with ID {id} not found." });
            }

            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student newStudent)
        {
            // Fixed: Removed the trailing semicolon after the condition
            if (string.IsNullOrWhiteSpace(newStudent.FirstName) || string.IsNullOrWhiteSpace(newStudent.LastName))
            {
                return BadRequest(new { message = "First name and Last name are required." });
            }

            // Auto-assign next ID
            newStudent.Id = students.Any() ? students.Max(s => s.Id) + 1 : 1;
            students.Add(newStudent);

            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.Id }, newStudent);
        }

        // PUT: api/student/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updateStudent)
        {
            if (id != updateStudent.Id)
            {
                return BadRequest(new { message = "ID mismatch" });
            }

            var existingStudent = students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return NotFound(new { message = $"Student with ID {id} not found." });
            }

            existingStudent.FirstName = updateStudent.FirstName;
            existingStudent.LastName = updateStudent.LastName;
            existingStudent.Course = updateStudent.Course;
            existingStudent.YearLevel = updateStudent.YearLevel;

            return NoContent();
        }

        // DELETE: api/student/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound(new { message = $"Student with ID {id} not found." });
            }

            students.Remove(student);
            return NoContent();
        }
        [HttpGet("course/{courseName}")]
        public IActionResult GetStudentByCourse(string courseName)
        {
            var filtered =students
                .Where(s => s.Course.Equals(courseName, StringComparison.OrdinalIgnoreCase))
                .ToList();
                
                return Ok(filtered);
        }
    } 
}