using Hahn.ApplicatonProcess.December2020.Application.Responses;

namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommandResponse: BaseResponse
    {
        public CreateApplicantCommandResponse():base()
        {
        }

        public CreateApplicantDto Applicant { get; set; }
    }
}