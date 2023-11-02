using Personal.GraphQLDemo.API.DataLoader;
using Personal.GraphQLDemo.API.DTOs;
using Personal.GraphQLDemo.API.Model.Enum;
using Personal.GraphQLDemo.API.Repository;

namespace Personal.GraphQLDemo.API.Schema
{
  
    public class CourseType
    {
       

       

        public Guid Id { get; set; }
        public string CourseName {  get; set; } 
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
        public InstructorType Instructor { get; set; }
        public async Task<InstructorType> InstructorAsync([Service] InstructorDataLayer instructorDataLayer) {

            var instructorDTO = await instructorDataLayer.LoadAsync(this.InstructorId);
            return new InstructorType()
            {
                Id=instructorDTO.Id,
                Name=instructorDTO.Name,
                Salary=instructorDTO.Salary,
            };


        }  
        public IEnumerable<StudentType> Students { get; set; } = Enumerable.Empty<StudentType>();
    }
}
