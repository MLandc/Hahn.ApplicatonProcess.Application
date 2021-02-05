using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.CreateApplicant;
using Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.DeleteApplicant;
using Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.UpdateApplicant;
using Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Queries.GetApplicantDetail;
using Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Queries.GetApplicantsList;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Applicant, ApplicantsListVM>().ReverseMap();
            CreateMap<Applicant, ApplicantDetailVM>().ReverseMap();
            CreateMap<Applicant, CreateApplicantCommand>().ReverseMap();
            CreateMap<Applicant, UpdateApplicantCommand>().ReverseMap();
            CreateMap<Applicant, DeleteApplicantCommand>().ReverseMap();
            CreateMap<Applicant, CreateApplicantDto>().ReverseMap();
        }
    }
}
