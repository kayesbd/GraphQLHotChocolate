using Personal.GraphQLDemo.API.Model.Enum;

namespace Personal.GraphQLDemo.API.Schema.CourseMutation
{
    public class CreateCourseResult
    {
        public Guid Id { get; set; }
        public string CourseName {  get; set; }
        public Subject subject { get; set; }
        public Guid InstructorId {  get; set; }
    }
}
