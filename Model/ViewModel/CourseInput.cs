using Personal.GraphQLDemo.API.Model.Enum;

namespace Personal.GraphQLDemo.API.Model.ViewModel
{
    public class CourseInput
    {
        //public Guid Id { get; set; }
        public string? CourseName { get; set; }
        public Subject Subject { get; set; }
      
        public Guid InstructorId { get; set; }
    }
}
