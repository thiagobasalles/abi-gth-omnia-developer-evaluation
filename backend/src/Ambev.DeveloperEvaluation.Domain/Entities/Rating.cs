using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Rating : BaseEntityLongId
    {

        /// <summary>
        /// Gets the avarage rating.
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Gets the max count votes.
        /// </summary>
        public int Count { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new RatingValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(r => (ValidationErrorDetail) r)
            };
        }
    }
}
