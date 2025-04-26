using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Sale> CreateAsync(Sale sale)
        {
            await _context.Sale.AddAsync(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var sale = await GetByIdAsync(id);
            if (sale == null)
                return false;
            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<Sale?> GetByIdAsync(long id)
        {
            return await _context.Sale.FindAsync(id);
        }

        public async Task UpdateAsync(Sale sale)
        {
            _context.Sale.Update(sale);
            await _context.SaveChangesAsync();
        }

    }
}
