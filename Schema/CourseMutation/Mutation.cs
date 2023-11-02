using Microsoft.AspNetCore.Mvc;
using Personal.GraphQLDemo.API.DTOs;
using Personal.GraphQLDemo.API.Model.Enum;
using Personal.GraphQLDemo.API.Model.ViewModel;
using Personal.GraphQLDemo.API.Repository;

namespace Personal.GraphQLDemo.API.Schema.CourseMutation
{
    public class CourseMutation
    {
        private readonly CourseRepository courseRepository;
        public CourseMutation(CourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

      

        public async Task<CreateCourseResult> CreateCourseAsync(CourseInput course)
        {
            CourseDTO courseType = new CourseDTO()
            {
                Id = Guid.NewGuid(),
                CourseName = course.CourseName,
                Subject = course.Subject,
                InstructorId = course.InstructorId

            };
            var newCourse = await courseRepository.CreateCourseAsync(courseType);
         
                return new CreateCourseResult()
                {
                    Id = newCourse.Id,
                    CourseName = newCourse.CourseName, 
                    subject = newCourse.Subject,
                    InstructorId = newCourse.InstructorId

                };
            
           
        }
        public async Task<CreateCourseResult> UpdateCourseAsync(CourseInput course)
        {
            CourseDTO courseType = new CourseDTO()
            {
                Id = Guid.NewGuid(),
                CourseName = course.CourseName,
                Subject = course.Subject,
                InstructorId = course.InstructorId

            };
            var newCourse = await courseRepository.UpdateCourseAsync(courseType);
            return new CreateCourseResult()
            {
                Id = newCourse.Id,
                CourseName = newCourse.CourseName,
                subject = newCourse.Subject,
                InstructorId = newCourse.InstructorId

            };
        }
        public async Task<bool> DeleteCourseAsync(Guid Id)
        {
           
            return await courseRepository.DeleteCourseAsync(Id);
           
        }
    }
}
