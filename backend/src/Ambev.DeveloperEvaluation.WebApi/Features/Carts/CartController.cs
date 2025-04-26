using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetangeCart;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetCartById;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetRangeCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateUpdateCart;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    /// <summary>
    /// Controller for managing cart operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CartController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CartController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCartByIdResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCartById([FromRoute] long id, CancellationToken cancellationToken)
        {
            var request = new GetCartByIdRequest { Id = id };
            var validator = new GetCartByIdRequestValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            GetCartByIdResult result = await GetCartByIdResponseAsync(request, cancellationToken);

            return Ok(result);

        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResponse<GetRangeCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRangeCart(
            [FromQuery(Name = "_page")] int page = 1,
            [FromQuery(Name = "_size")] int size = 10,
            [FromQuery(Name = "_order")] string order = "",
            CancellationToken cancellationToken = default)
        {
            var request = new GetRangeCartRequest {Page = page, Size = size, Order = order };
            var validator = new GetRangeCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            PaginatedResponse<GetRangeCartResponse> responsePage = await GetRangeCartResponseAsync(request, cancellationToken);

            return Ok(responsePage);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateUpdateCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCart([FromBody] CreateUpdateCartRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateUpdateCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateUpdateCartCommand>(request);

            var result = await _mediator.Send(command, cancellationToken);

            var response = _mapper.Map<CreateUpdateCartResponse>(result);

            return Created(string.Empty, new ApiResponseWithData<CreateUpdateCartResponse>
            {
                Success = true,
                Message = "Cart created successfully",
                Data = _mapper.Map<CreateUpdateCartResponse>(response)
            });
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCart([FromRoute] long id, CancellationToken cancellationToken)
        {

            var request = new DeleteCartRequest { Id = id };
            var validator = new DeleteCartRequestValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            var command = _mapper.Map<DeleteCartCommand>(request);

            await _mediator.Send(command, cancellationToken);

            return Ok($"Cart with id {id} has been deleted");

        }

        private async Task<PaginatedResponse<GetRangeCartResponse>> GetRangeCartResponseAsync(GetRangeCartRequest getCartRequest, CancellationToken cancellationToken)
        {
            var getCartCommand = _mapper.Map<GetRangeCartCommand>(getCartRequest);
            var result = await _mediator.Send(getCartCommand, cancellationToken);

            var response = result.ProjectTo<GetRangeCartResponse>(_mapper.ConfigurationProvider);

            var paginatedList = await PaginatedList<GetRangeCartResponse>.CreateAsync(response, getCartRequest.Page, getCartRequest.Size);

            var responsePage = new PaginatedResponse<GetRangeCartResponse>
            {
                Data = paginatedList.AsEnumerable(),
                CurrentPage = paginatedList.CurrentPage,
                TotalPages = paginatedList.TotalPages,
                TotalCount = paginatedList.TotalCount,
                Success = true,
                Message = "Carrinho atualizado com sucesso"
            };
            return responsePage;
        }
        private async Task<GetCartByIdResult> GetCartByIdResponseAsync(GetCartByIdRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<GetCartByIdCommand>(request);

            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }
    }
}
