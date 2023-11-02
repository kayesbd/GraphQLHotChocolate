using Bogus;
using Microsoft.EntityFrameworkCore;
using Personal.GraphQLDemo.API.DTOs;
using Personal.GraphQLDemo.API.Model.Enum;
using Personal.GraphQLDemo.API.Repository;
using Personal.GraphQLDemo.API.Services;
using System.Runtime.InteropServices;

namespace Personal.GraphQLDemo.API.Schema
{
    public class Query
    {
        private readonly CourseRepository _courseRepository;

        public Query(CourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }



        [UseFiltering]
        public async Task<IEnumerable<CourseType>> GetCourses()
        {
            List<CourseDTO> courseDTOs = await _courseRepository.GetAllCourseAsync();
            
            return courseDTOs.Select(x => new CourseType()
            {
                Id = x.Id,
                CourseName = x.CourseName,
                Subject = x.Subject,
                InstructorId=x.InstructorId
                //Instructor = new InstructorType()
                //{
                //    Id = x.Id,
                //    Name = x.Instructor.Name,
                //    Salary = x.Instructor.Salary,

                //}
            });


        }
        [UseDbContext(typeof(CampusDBContext))]
        [UsePaging(IncludeTotalCount = true, MaxPageSize = 5)]
        public IQueryable<CourseType> GetPaginatedCourses([ScopedService] CampusDBContext campusDBContext)
        {
          

            return campusDBContext.Courses.Select(x => new CourseType()
            {
                Id = x.Id,
                CourseName = x.CourseName,
                Subject = x.Subject,
                InstructorId = x.InstructorId
                //Instructor = new InstructorType()
                //{
                //    Id = x.Id,
                //    Name = x.Instructor.Name,
                //    Salary = x.Instructor.Salary,

                //}
            });


        }
        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {

            CourseDTO courseDTO= await _courseRepository.GetCourseById(id);

            return new CourseType()
            {
                Id = courseDTO.Id,
                CourseName = courseDTO.CourseName,
                Subject = courseDTO.Subject,
                InstructorId = courseDTO.InstructorId
            };
        }
     
    }
}
