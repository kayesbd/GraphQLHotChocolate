using Personal.GraphQLDemo.API.Model.Enum;
using Personal.GraphQLDemo.API.Schema;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal.GraphQLDemo.API.DTOs
{
    public class CourseDTO
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public Subject Subject { get; set; }
        
        public Guid InstructorId { get; set; }
       // [ForeignKey(nameof(InstructorId))]
   
        public virtual InstructorDTO Instructor { get; set; }
        public IEnumerable<StudentDTO> Students { get; set; } 
    }
}
