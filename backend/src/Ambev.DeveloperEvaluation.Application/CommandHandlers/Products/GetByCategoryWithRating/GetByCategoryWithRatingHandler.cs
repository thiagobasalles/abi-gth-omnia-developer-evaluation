using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByCategoryWithRating
{
    public class GetByCategoryWithRatingHandler : IRequestHandler<GetByCategoryWithRatingCommand, IQueryable<GetByCategoryWithRatingResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetByCategoryWithRatingHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public Task<IQueryable<GetByCategoryWithRatingResult>> Handle(GetByCategoryWithRatingCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetByCategoryWithRatingValidator();
            var validatorResult = validator.Validate(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            var productDb = _productRepository.GetByCategoryWithRatingPaginatedIqueryable(request.Category, request.Order);


            var productMap = productDb.ProjectTo<GetByCategoryWithRatingResult>(_mapper.ConfigurationProvider);
            return Task.FromResult(productMap);
        }
    }
}
