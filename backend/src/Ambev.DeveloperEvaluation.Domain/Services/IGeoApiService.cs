using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Dtos;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface IGeoApiService
    {
        public Task<GeoApiDto> GetByAddress(string address);
    }
}
