using Personal.GraphQLDemo.API.DTOs;
using Personal.GraphQLDemo.API.Repository;

namespace Personal.GraphQLDemo.API.DataLoader
{
    public class InstructorDataLayer : BatchDataLoader<Guid, InstructorDTO>
    {
        private InstructorRepository _instructorRepository;

        public InstructorDataLayer(InstructorRepository instructorRepository,IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
        {
            _instructorRepository = instructorRepository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, InstructorDTO>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            IEnumerable<InstructorDTO> instructors = await _instructorRepository.GetManyInstructorByIdAsync(keys);
            return instructors.ToDictionary(x => x.Id);
             
        }
    }
}
