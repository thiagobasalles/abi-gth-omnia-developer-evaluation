using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.PreApprove;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetRangeCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateUpdateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.PreApprove;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Approve;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.Approve;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Cancel;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.Cancel;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of SaleController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public SaleController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("pre-approve/{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<PreApproveResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PreApprove([FromRoute(Name="id")] long cartId,[FromQuery] long branchId, CancellationToken cancellationToken)
        {
            var request = new PreApproveRequest{ CartId = cartId, BranchId = branchId };
            var validator = new PreApproveRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<PreApproveCommand>(request);

            var result = await _mediator.Send(command, cancellationToken);

            var response = _mapper.Map<PreApproveResponse>(result);

            return Created(string.Empty, new ApiResponseWithData<PreApproveResponse>
            {
                Success = true,
                Message = "Sale pre-approved successfully",
                Data = _mapper.Map<PreApproveResponse>(response)
            });

        }


        [HttpPatch("approve/{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Approve([FromRoute(Name ="id")] long id, CancellationToken cancellationToken)
        {
            var request = new ApproveRequest { Id = id};
            var validator = new ApproveRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);



            var command = _mapper.Map<ApproveCommand>(request);

            await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponse
            {
                Success = true,
                Message = "Sale approved successfully",
            });

        }

        [HttpPatch("cancel/{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Cancel([FromRoute] long id, CancellationToken cancellationToken)
        {
            var request = new CancelRequest { Id = id };
            var validator = new CancelRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CancelCommand>(request);

            await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponse
            {
                Success = true,
                Message = "Sale cancelled successfully",
            });

        }

    }
}
