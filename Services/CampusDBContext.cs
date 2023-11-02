using Microsoft.EntityFrameworkCore;
using Personal.GraphQLDemo.API.DTOs;

namespace Personal.GraphQLDemo.API.Services
{
    public class CampusDBContext:DbContext
    {
        public CampusDBContext(DbContextOptions<CampusDBContext> options):base(options)
        {

        }

        public DbSet<CourseDTO> Courses { get; set; }
        public DbSet<InstructorDTO> Instructors { get; set; }
        public DbSet<StudentDTO> Students { get; set; }

    }
}
