using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.UpdateApplicant
{
    public class UpdateApplicantCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Adress { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EMailAdress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }

        public override string ToString()
        {
            return $"Applicant name: {Name}, family name: {FamilyName}, address: {Adress}, " +
                $"country of origin: {CountryOfOrigin}, email: {EMailAdress}, age: {Age}, hired:{Hired}.";
        }
    }
}
