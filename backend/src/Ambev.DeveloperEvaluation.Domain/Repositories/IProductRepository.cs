using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves a product by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        Task<Product?> GetByIdWithRatingAsync(long id, CancellationToken cancellationToken = default);

        IQueryable<Product> GetPaginatedIqueryable(string order);

        Task<Product> CreateAsync (Product product, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken);
        IQueryable<Product> GetByCategoryWithRatingPaginatedIqueryable(string category, string order);
        Task<IList<string>> GetAllCategories();
        Task DeleteAsync(long id, CancellationToken cancellationToken);
    }
}
