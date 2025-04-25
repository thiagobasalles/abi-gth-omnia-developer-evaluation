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
    public class Address : BaseEntityLongId
    {

        public Guid UserId { get; set; }

        /// <summary>
        /// Gets the city of user.
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets the street of user.
        /// </summary>
        /// 
        public string Street { get; set; } = string.Empty;

        public int Number { get; set; }

        /// <summary>
        /// Gets the zipcode of user.
        /// </summary>
        public string Zipcode { get; set; } = string.Empty;

        public User? User { get; set; }

        /// <summary>
        /// Gets the geolocation of user.
        /// </summary>
        public GeoLocation? Geolocation { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new AddressValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
