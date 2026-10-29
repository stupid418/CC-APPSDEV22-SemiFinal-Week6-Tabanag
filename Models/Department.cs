using System.Collections.Generic;

namespace StudentRosterDbApi.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        
        // This MUST use curly braces { get; set; } and NOT parentheses ()
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
