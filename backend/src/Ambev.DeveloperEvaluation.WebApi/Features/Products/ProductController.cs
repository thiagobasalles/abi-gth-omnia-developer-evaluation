using Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetPaginatedProducts;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByIdWithRating;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetPaginatedProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductById;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetAllCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByCategoryWithRating;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByCategoryWithRating;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of ProductController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        /// <summary>
        /// Retrieves a product page
        /// </summary>
        /// <param name="page">The page number to retrieve (default is 1).</param>
        /// <param name="size">The number of items per page (default is 10).</param>
        /// <param name="order">The sorting criteria, e.g., "title asc, price desc".</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product details if found</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResponse<GetByIdWithRatingResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaginatedProducts(
            [FromQuery(Name = "_page")] int page = 1,
            [FromQuery(Name = "_size")] int size = 10,
            [FromQuery(Name = "_order")] string order = "",
            CancellationToken cancellationToken = default)
        {

            var getProductsRequest = new GetPaginatedProductsRequest { Page = page, Size = size, Order = order};
            var validator = new GetProductRequestValidator();
            var validatorResult = validator.Validate(getProductsRequest);
            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);


            var command = _mapper.Map<GetPaginatedProductsCommand>(getProductsRequest);
            var result = await _mediator.Send(command, cancellationToken);

            var response = result.ProjectTo<GetByIdWithRatingResponse>(_mapper.ConfigurationProvider);

            var pageResponse = await PaginatedList<GetByIdWithRatingResponse>.CreateAsync(response, page, size);

            return OkPaginated(pageResponse);
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="request">The product creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<GetByIdWithRatingRatingResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateProductCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            GetByIdWithRatingResponse response = await HandlerGetByIdWithRatingRequest(new GetByIdWithRatingRequest { Id = result}, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<GetByIdWithRatingResponse>
            {
                Success = true,
                Message = "Product created successfully",
                Data = response
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetByIdWithRatingResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdWithRating([FromRoute] long id, CancellationToken cancellationToken)
        {
            var request = new GetByIdWithRatingRequest { Id = id };
            var validator = new GetByIdWithRatingRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            GetByIdWithRatingResponse response = await HandlerGetByIdWithRatingRequest(request, cancellationToken);

            return Ok(new ApiResponseWithData<GetByIdWithRatingResponse>
            {
                Data = response,
                Success = true,
                Message = "Product retrieved successfully"
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id, CancellationToken cancellationToken)
        {
            var request = new DeleteProductRequest { Id = id };
            var validator = new DeleteProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var productResult = await HandlerGetByIdWithRatingRequest(new GetByIdWithRatingRequest { Id = id }, cancellationToken);
            var productResponse = _mapper.Map<GetByIdWithRatingResponse>(productResult);// Solicitação da API DOC...

            var command = _mapper.Map<DeleteProductCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetByIdWithRatingResponse>
            {
                Success = true,
                Message = "Product deleted successfully",
                Data = productResponse
            });
        }

        [HttpGet("categories")]
        [ProducesResponseType(typeof(ApiResponseWithData<IList<String>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCategories(
            CancellationToken cancellationToken = default
        )
        {
            var result = await _mediator.Send(new GetAllCategoriesCommand(), cancellationToken);
            return Ok(new ApiResponseWithData<IList<string>>
            {
                Success = true,
                Message = "Categories retrieved successfully",
                Data = result
            });
        }


        [HttpGet("category/{category}")]
        [ProducesResponseType(typeof(ApiResponseWithData<PaginatedResponse<GetByIdWithRatingResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCategoriesWithRating(
                [FromRoute(Name = "category")] string category,
                [FromQuery(Name = "_page")] int page = 1,
                [FromQuery(Name = "_size")] int size = 10,
                [FromQuery(Name = "_order")] string order = "",
                CancellationToken cancellationToken = default
            )
        {
            var request = new GetByCategoryWithRatingRequest { Category = category, Page = page, Size = size, Order = order};
            var validator = new GetByCategoryWithRatingRequestValidator();
            var validatorResult = validator.Validate(request);
            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            var command = _mapper.Map<GetByCategoryWithRatingCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            var response = result.ProjectTo<GetByIdWithRatingResponse>(_mapper.ConfigurationProvider);
            var pageResponse = await PaginatedList<GetByIdWithRatingResponse>.CreateAsync(response, page, size);
            return OkPaginated(pageResponse);
        }

        private async Task<GetByIdWithRatingResponse> HandlerGetByIdWithRatingRequest(GetByIdWithRatingRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<GetByIdWithRatingCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            var response = _mapper.Map<GetByIdWithRatingResponse>(result);
            return response;
        }
    }
}
