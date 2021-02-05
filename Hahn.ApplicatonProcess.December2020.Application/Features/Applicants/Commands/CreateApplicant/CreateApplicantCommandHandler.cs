using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Application.Contracts.Persistence;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, CreateApplicantCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicantRepository _applicantRepository;
        private readonly ILogger<CreateApplicantCommandHandler> _logger;

        public CreateApplicantCommandHandler(IMapper mapper, IApplicantRepository applicantRepository, ILogger<CreateApplicantCommandHandler> logger)
        {
            _mapper = mapper;
            _applicantRepository = applicantRepository;
            _logger = logger;
        }

        public async Task<CreateApplicantCommandResponse> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Create new applicant with name {request.Name} and family name {request.FamilyName}");

            var createApplicantCommandResponse = new CreateApplicantCommandResponse();

            var validator = new CreateApplicantCommandValidator(_applicantRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createApplicantCommandResponse.Success = false;
                createApplicantCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    createApplicantCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

                _logger.LogError($"Failed to create new applicant with name {request.Name} and family name {request.FamilyName}", validationResult.Errors);
            }

            if (createApplicantCommandResponse.Success)
            {
                var applicant = _mapper.Map<Applicant>(request);
                applicant = await _applicantRepository.AddAsync(applicant);
                createApplicantCommandResponse.Applicant = _mapper.Map<CreateApplicantDto>(applicant);
            }
            
            return createApplicantCommandResponse;
        }
    }
}
