using System;

namespace Hahn.ApplicatonProcess.December2020.Application.Exception
{
    public class BadRequestException: ApplicationException
    {
        public BadRequestException(string message): base(message)
        {

        }
    }
}
