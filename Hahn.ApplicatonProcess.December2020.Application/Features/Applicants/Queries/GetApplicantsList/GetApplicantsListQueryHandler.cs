using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Application.Contracts.Persistence;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Queries.GetApplicantsList
{
    public class GetApplicantsListQueryHandler : IRequestHandler<GetApplicantsListQuery, List<ApplicantsListVM>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Applicant> _applicantRepository;

        public GetApplicantsListQueryHandler(IMapper mapper, IAsyncRepository<Applicant> applicantRepository)
        {
            _mapper = mapper;
            _applicantRepository = applicantRepository;
        }

        public async Task<List<ApplicantsListVM>> Handle(GetApplicantsListQuery request, CancellationToken cancellationToken)
        {
            var allApplicants = (await _applicantRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<ApplicantsListVM>>(allApplicants);
        }
    }
}
