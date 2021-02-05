using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Application.Contracts.Persistence;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.DeleteApplicant
{
    public class DeleteApplicantCommandHandler : IRequestHandler<DeleteApplicantCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Applicant> _applicantRepository;

        public DeleteApplicantCommandHandler(IMapper mapper, IAsyncRepository<Applicant> applicantRepository)
        {
            _mapper = mapper;
            _applicantRepository = applicantRepository;
        }

        public async Task<Unit> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicantToDelete = await _applicantRepository.GetByIdAsync(request.Id);
            await _applicantRepository.DeleteAsync(applicantToDelete);
            return Unit.Value;
        }
    }
}
