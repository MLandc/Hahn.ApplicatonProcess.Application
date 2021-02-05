using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Application.Contracts.Persistence;
using Hahn.ApplicatonProcess.December2020.Application.Exception;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.UpdateApplicant
{
    public class UpdateApplicantCommandHandler : IRequestHandler<UpdateApplicantCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicantRepository _applicantRepository;

        public UpdateApplicantCommandHandler(IMapper mapper, IApplicantRepository applicantRepository)
        {
            _mapper = mapper;
            _applicantRepository = applicantRepository;
        }
        public async Task<Unit> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicantToUpdate = await _applicantRepository.GetByIdAsync(request.Id);
            if (applicantToUpdate == null)
            {
                throw new NotFoundException(nameof(Applicant), request.Id);
            }

            var validator = new UpdateApplicantCommandValidator(_applicantRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, applicantToUpdate, typeof(UpdateApplicantCommand), typeof(Applicant));
            await _applicantRepository.UpdateAsync(applicantToUpdate);
            return Unit.Value;


        }
    }
}
