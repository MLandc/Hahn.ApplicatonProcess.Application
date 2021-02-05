using Hahn.ApplicatonProcess.December2020.Application.Contracts.Persistence;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Persistence.Repositories
{
    public class ApplicantRepository : BaseRepository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(HahnApplicationProcessDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsApplicantNameUnique(string name, string familyName)
        {
            var matches = _dbContext.Applicants.Any(e => e.Name.Equals(name) && e.Name.Equals(familyName));
            return Task.FromResult(matches);
        }
    }
}
