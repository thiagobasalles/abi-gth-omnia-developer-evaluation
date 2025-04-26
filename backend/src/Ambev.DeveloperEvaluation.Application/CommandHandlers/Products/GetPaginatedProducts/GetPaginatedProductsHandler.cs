using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetPaginatedProducts
{
    public class GetPaginatedProductsHandler : IRequestHandler<GetPaginatedProductsCommand, IQueryable<GetPaginatedProductsResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetPaginatedProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public Task<IQueryable<GetPaginatedProductsResult>> Handle(GetPaginatedProductsCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetPaginatedProductsValidator();
            var validatorResult = validator.Validate(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            var productQuerable = _productRepository.GetPaginatedIqueryable(request.Order);
            var getProductResultQueryable = productQuerable.ProjectTo<GetPaginatedProductsResult>(_mapper.ConfigurationProvider);
            return Task.FromResult(getProductResultQueryable);
        }
    }
}
