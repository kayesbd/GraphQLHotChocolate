using Microsoft.EntityFrameworkCore;
using Personal.GraphQLDemo.API.DTOs;
using Personal.GraphQLDemo.API.Services;

namespace Personal.GraphQLDemo.API.Repository
{
    public class InstructorRepository
    {
        private readonly IDbContextFactory<CampusDBContext> dbContextFactory;

        public InstructorRepository(IDbContextFactory<CampusDBContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<InstructorDTO> CreateInstructorAsync(InstructorDTO course)
        {
            using (CampusDBContext context = dbContextFactory.CreateDbContext())
            {

                context.Instructors.Add(course);
                await context.SaveChangesAsync();
                return course;
            }
        }
        public async Task<List<InstructorDTO>> GetAllInstructorAsync()
        {
            using (CampusDBContext context = dbContextFactory.CreateDbContext())
            {


                return await context.Instructors.
                    //Include(x => x.InstructorId).
                    ToListAsync();


            }
        }
        public async Task<InstructorDTO> GetInstructorByIdAsync(Guid id)
        {
            using (CampusDBContext context = dbContextFactory.CreateDbContext())
            {


                return await context.Instructors.
                    //Include(c=>c.InstructorId).
                    FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("The value is not found in storage!");

            }
        }
        public async Task<IEnumerable<InstructorDTO>> GetManyInstructorByIdAsync(IReadOnlyList<Guid> ids)
        {
            using (CampusDBContext context = dbContextFactory.CreateDbContext())
            {


                return await context.Instructors.Where(x=>ids.Contains(x.Id)).ToListAsync();
                    

            }
        }
        
    }
}
