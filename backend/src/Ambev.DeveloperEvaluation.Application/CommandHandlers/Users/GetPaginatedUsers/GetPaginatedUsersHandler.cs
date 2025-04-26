using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper.QueryableExtensions;

namespace Ambev.DeveloperEvaluation.Application.Users.GetPaginatedUsers;

/// <summary>
/// Handler for processing GetPaginatedUsersCommand requests
/// </summary>
public class GetPaginatedUsersHandler : IRequestHandler<GetPaginatedUsersCommand, IQueryable<GetPaginatedUsersResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetPaginatedUsersHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public GetPaginatedUsersHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetPaginatedUsersCommand request
    /// </summary>
    /// <param name="request">The GetPaginatedUsers command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    public async Task<IQueryable<GetPaginatedUsersResult>> Handle(GetPaginatedUsersCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetPaginatedUsersValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = _userRepository.GetAllUsersQuery(request.Order);
        var resultQueryable = user.ProjectTo<GetPaginatedUsersResult>(_mapper.ConfigurationProvider);

        return resultQueryable;
    }
}
