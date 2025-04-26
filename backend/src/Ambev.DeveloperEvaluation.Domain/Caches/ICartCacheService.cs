using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Caches
{
    public interface ICartCacheService
    {
        Task<Cart?> GetCartByIdAsync(long id);
        Task Delete(long id);
        Task<IQueryable<Cart>> GetQueryableAsync();
        Task<Cart> AddASync(Cart cart);
        Task Update(Cart cart);
    }
}
