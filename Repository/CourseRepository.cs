using Microsoft.EntityFrameworkCore;
using Personal.GraphQLDemo.API.DTOs;
using Personal.GraphQLDemo.API.Model.ViewModel;
using Personal.GraphQLDemo.API.Schema;
using Personal.GraphQLDemo.API.Schema.CourseMutation;
using Personal.GraphQLDemo.API.Services;

namespace Personal.GraphQLDemo.API.Repository
{
    public class CourseRepository
    {
        private readonly IDbContextFactory<CampusDBContext> dbContextFactory;

        public CourseRepository(IDbContextFactory<CampusDBContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<CourseDTO> CreateCourseAsync(CourseDTO course)
        {
            using (CampusDBContext context = dbContextFactory.CreateDbContext())
            {

                context.Courses.Add(course);
                await context.SaveChangesAsync();
                return course;
            }
        }
        public async Task<List<CourseDTO>> GetAllCourseAsync()
        {
            using (CampusDBContext context = dbContextFactory.CreateDbContext())
            {


               List<CourseDTO> result= await context.Courses.
                   // Include(x => x.InstructorId).
                    ToListAsync();
                return result;
               
                    
               
            }
        }
        public async Task<CourseDTO> GetCourseById(Guid id)
        {
            using (CampusDBContext context = dbContextFactory.CreateDbContext())
            {


                return await context.Courses.
                    //Include(c=>c.InstructorId).
                    FirstOrDefaultAsync(x=>x.Id==id)?? throw new Exception("The value is not found in storage!");
               
            }
        }
        public async Task<CourseDTO> UpdateCourseAsync(CourseDTO course)
        {
            using (CampusDBContext context = dbContextFactory.CreateDbContext())
            {

                context.Courses.Update(course);
                await context.SaveChangesAsync();
                return course;
            }

        }
        public async Task<bool> DeleteCourseAsync(Guid courseId)
        {
            int res;
            var course = new CourseDTO()
            {
                Id = courseId

            };

            using (CampusDBContext context = dbContextFactory.CreateDbContext())
            {

                context.Courses.Remove(course);
                 res=await context.SaveChangesAsync();
               
            }
            return res>0;

        }
    }
}
