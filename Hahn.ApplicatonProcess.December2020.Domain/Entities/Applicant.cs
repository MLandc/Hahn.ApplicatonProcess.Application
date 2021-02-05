using Hahn.ApplicatonProcess.December2020.Domain.Common;

namespace Hahn.ApplicatonProcess.December2020.Domain.Entities
{
    public class Applicant : AuditableEntity
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
