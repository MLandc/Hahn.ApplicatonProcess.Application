using MediatR;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Queries.GetApplicantsList
{
    public class GetApplicantsListQuery : IRequest<List<ApplicantsListVM>>
    {
    }
}
