using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Services;
using Nominatim.API.Address;
using Nominatim.API.Geocoders;
using Nominatim.API.Interfaces;
using Nominatim.API.Models;

namespace Ambev.DeveloperEvaluation.ApiGeoService.Services
{
    public class NominatimApiService : IGeoApiService
    {
        private readonly IAddressSearcher _addressSearcher;
        private readonly IForwardGeocoder _forwardGeocoder;
        public NominatimApiService(IAddressSearcher  addressSearcher, IForwardGeocoder forwardGeocoder)
        {
            _addressSearcher = addressSearcher;
            _forwardGeocoder = forwardGeocoder;
        }

        public async Task<GeoApiDto> GetByAddress(string address)
        {
            var request = new ForwardGeocodeRequest
            {
                queryString = "Av Tenente Coronel Muniz de Aragão 800",
            };

            var response = (await _forwardGeocoder.Geocode(request))[0];

            var dto = new GeoApiDto
            {
                Lat = response.Latitude,
                Lon = response.Longitude
            };

            return dto;
        }
    }
}
