namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Queries.GetApplicantDetail
{
    public class ApplicantDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Adress { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EMailAdress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }
    }
}