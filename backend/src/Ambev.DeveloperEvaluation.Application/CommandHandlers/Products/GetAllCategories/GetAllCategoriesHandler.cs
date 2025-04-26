using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesCommand, IList<string>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllCategoriesHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IList<string>> Handle(GetAllCategoriesCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllCategories();
        }
    }
}
