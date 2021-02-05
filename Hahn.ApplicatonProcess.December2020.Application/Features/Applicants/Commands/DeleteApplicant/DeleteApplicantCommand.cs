using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.DeleteApplicant
{
    public class DeleteApplicantCommand: IRequest
    {
        public int Id { get; set; }
    }
}
