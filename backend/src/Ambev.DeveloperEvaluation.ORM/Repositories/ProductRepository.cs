using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of ProductRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public ProductRepository(DefaultContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetPaginatedIqueryable(string order)
        {
            var queryable = _context.Product
                .Include(p => p.Rating)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(order))
            {
                queryable = queryable.OrderBy(order);
            }

            return queryable;   
        }

        public async Task<Product?> GetByIdWithRatingAsync(long id, CancellationToken cancellationToken = default)
        {

            return await _context.Product.Include(p => p.Rating).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Product.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Product.Update(product);
            return (await _context.SaveChangesAsync(cancellationToken)) == 0 ? false : true;
        }

        public async Task<IList<string>> GetAllCategories()
        {
            return await _context.Product.Select(p => p.Category).Distinct().ToListAsync();
        }

        public IQueryable<Product> GetByCategoryWithRatingPaginatedIqueryable(string category, string order)
        {
            var queryable = _context.Product
                .Include(p => p.Rating)
                .Where(p => p.Category == category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(order))
            {
                queryable = queryable.OrderBy(order);
            }

            return queryable;
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var product = await _context.Product.FindAsync(id, cancellationToken);
            if (product == null)
                throw new KeyNotFoundException($"Product ID {id} not found");

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
