using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.UpdateUser
{
    public class UpdateUserGeolocationDto
    {
        /// <summary>
        /// Get's the Latitude 
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Get's the Longitude
        /// </summary>
        public double Long { get; set; }
    }
}
