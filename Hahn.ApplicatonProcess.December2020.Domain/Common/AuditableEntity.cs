using System;

namespace Hahn.ApplicatonProcess.December2020.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
