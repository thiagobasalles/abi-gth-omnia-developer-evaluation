using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.GetPaginatedUsers
{
    public class GetPaginatedUsersNameDto
    {
        /// <summary>
        /// Gets or sets firstname of user
        /// </summary>
        public string Firstname { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets lastname of user
        /// </summary>
        public string Lastname { get; set; } = string.Empty;
    }
}
