using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class GeoLocation : BaseEntityLongId
    {

        /// <summary>
        /// Gets the Address Id
        /// </summary>
        public long AddressId { get; set; }

        /// <summary>
        /// Get's the Latitude 
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Get's the Longitude
        /// </summary>
        public double Long { get; set; }

        public Address? Address { get; set; } = new();

        public static GeoLocation AddLatLong(double lat, double longi)
        {
            GeoLocation geoLocation = new GeoLocation
            {
                Lat = lat,
                Long = longi
            };
            return geoLocation;
        }
    }
}
