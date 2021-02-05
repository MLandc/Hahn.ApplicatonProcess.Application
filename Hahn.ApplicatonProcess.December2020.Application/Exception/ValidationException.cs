using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Application.Exception
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            foreach(var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
