using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetPaginatedUsers;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.GetPaginatedUsers;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetByIdWithAddress;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.GetByIdWithAddress;
using AutoMapper.QueryableExtensions;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.UpdateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users;

/// <summary>
/// Controller for managing user operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    /// <summary>
    /// Initializes a new instance of UsersController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves a user and address by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetByIdWithAddressResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdWithAddress([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetByIdWithAddressRequest { Id = id };
        var validator = new GetByIdWithAddressRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        GetByIdWithAddressResponse responseHandler = await HandleGetByIdWithAddressRequest(request, cancellationToken);
        var responseMap = _mapper.Map<GetByIdWithAddressResponse>(responseHandler);

        return Ok(new ApiResponseWithData<GetByIdWithAddressResponse>
        {
            Success = true,
            Message = "User retrieved successfully",
            Data = responseMap
        });
    }

    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <param name="request">The user creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<GetByIdWithAddressResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateUserCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        var response = await HandleGetByIdWithAddressRequest(new GetByIdWithAddressRequest{ Id = result}, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<GetByIdWithAddressResponse>
        {
            Success = true,
            Message = "User created successfully",
            Data = response
        });
    }

    /// <summary>
    /// Retrieves a user by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedResponse<GetByIdWithAddressResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPaginatedUsers(
            [FromQuery(Name = "_page")] int page = 1,
            [FromQuery(Name = "_size")] int size = 10,
            [FromQuery(Name = "_order")] string order = "",
            CancellationToken cancellationToken = default
        )
    {
        var request = new GetPaginatedUsersRequest { Page = page, Size = size, Order = order };
        var validator = new GetPagintedUsersRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetPaginatedUsersCommand>(request);

        var result = await _mediator.Send(command, cancellationToken);

        var resultMap = result.ProjectTo<GetByIdWithAddressResponse>(_mapper.ConfigurationProvider);

        var resultPaginated = await PaginatedList<GetByIdWithAddressResponse>.CreateAsync(resultMap, request.Page, request.Size);


        return OkPaginated(resultPaginated);
    }

    /// <summary>
    /// Deletes a user by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the user was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteUserRequest { Id = id };
        var validator = new DeleteUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var userResult = await HandleGetByIdWithAddressRequest(new GetByIdWithAddressRequest { Id = id }, cancellationToken);
        var userResponse= _mapper.Map<GetByIdWithAddressResponse>(userResult);// Solicitação da API DOC...

        var command = _mapper.Map<DeleteUserCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetByIdWithAddressResponse>
        {
            Success = true,
            Message = "User deleted successfully",
            Data = userResponse
        });
    }

    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<GetByIdWithAddressResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateUserCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        var response = await HandleGetByIdWithAddressRequest(new GetByIdWithAddressRequest { Id = result }, cancellationToken);

        return Ok(new ApiResponseWithData<GetByIdWithAddressResponse>
        {
            Success = true,
            Message = "User deleted successfully",
            Data = response
        });
    }

    
    private async Task<GetByIdWithAddressResponse> HandleGetByIdWithAddressRequest(GetByIdWithAddressRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<GetByIdWithAddressCommand>(request);

        var result = await _mediator.Send(command, cancellationToken);
        var response = _mapper.Map<GetByIdWithAddressResponse>(result);
        return response;
    }
}
