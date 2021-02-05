using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Application.Contracts.Persistence
{
    public interface IApplicantRepository : IAsyncRepository<Applicant>
    {
        Task<bool> IsApplicantNameUnique(string name, string familyName);
    }
}
