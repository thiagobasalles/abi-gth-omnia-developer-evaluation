using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.CreateUser
{
    public class CreateUserAddressDto
    {
        /// <summary>
        /// Gets or sets City of user.
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets the street of user.
        /// </summary>
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Gets the street of user.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets the zipcode of user.
        /// </summary>
        public string Zipcode { get; set; } = string.Empty;

        /// <summary>
        /// Gets the geolocation of address.
        /// </summary>
        public CreateUserGeolocationDto Geolocation {  get; set; } = new CreateUserGeolocationDto();

        public override string ToString()
        {
            return $"{City} {Street} {Number} {Zipcode}";
        }
    }
}
