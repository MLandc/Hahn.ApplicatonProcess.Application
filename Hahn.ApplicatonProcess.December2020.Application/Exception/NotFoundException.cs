using System;

namespace Hahn.ApplicatonProcess.December2020.Application.Exception
{
    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string name, object key)
            :base($"{name} ({key}) is not found")
        {

        }
    }
}
