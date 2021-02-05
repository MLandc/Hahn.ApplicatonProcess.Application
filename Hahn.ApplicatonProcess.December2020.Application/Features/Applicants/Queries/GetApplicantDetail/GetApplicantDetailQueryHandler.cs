using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Application.Contracts.Persistence;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Queries.GetApplicantDetail
{
    public class GetApplicantDetailQueryHandler : IRequestHandler<GetApplicantDetailQuery, ApplicantDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Applicant> _applicantRepository;

        public GetApplicantDetailQueryHandler(IMapper mapper, IAsyncRepository<Applicant> applicantRepository)
        {
            _mapper = mapper;
            _applicantRepository = applicantRepository;
        }

        public async Task<ApplicantDetailVM> Handle(GetApplicantDetailQuery request, CancellationToken cancellationToken)
        {
            var aplicant = await _applicantRepository.GetByIdAsync(request.Id);
            var applicantDto = _mapper.Map<ApplicantDetailVM>(aplicant);

            return applicantDto;
        }
    }
}
