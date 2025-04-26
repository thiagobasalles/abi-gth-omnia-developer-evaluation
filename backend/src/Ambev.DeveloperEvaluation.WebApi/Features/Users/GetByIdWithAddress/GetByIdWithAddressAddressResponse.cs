namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetByIdWithAddress
{
    public class GetByIdWithAddressAddressResponse
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
        /// Gets the geolocation of address
        /// </summary>
        public GetByIdWithAddressGeolocationResponse Geolocation { get; set; } = new GetByIdWithAddressGeolocationResponse();
    }
}
