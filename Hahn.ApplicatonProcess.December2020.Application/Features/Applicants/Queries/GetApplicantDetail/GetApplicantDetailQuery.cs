using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Queries.GetApplicantDetail
{
    public class GetApplicantDetailQuery : IRequest<ApplicantDetailVM>
    {
        public int Id { get; set; }
    }
}
