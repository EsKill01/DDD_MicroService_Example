using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appoitment.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(List<ValidationFailure> failures) : base(BuildErrorMessage(failures))
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                this.failures.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> failures = new Dictionary<string, string[]>();

        private static string BuildErrorMessage(IEnumerable<ValidationFailure> errors)
        {
            IEnumerable<string> values = errors.Select((ValidationFailure x) => Environment.NewLine + " -- " + x.PropertyName + ": " + x.ErrorMessage + " Severity: " + x.Severity);
            return "Validation failed: " + string.Join(string.Empty, values);
        }
    }
}