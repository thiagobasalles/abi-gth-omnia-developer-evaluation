using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.GetByIdWithAddress;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.GetByIdWithAddress
{
    public class GetByIdWithAddressHandler : IRequestHandler<GetByIdWithAddressCommand, GetByIdWithAddressResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetByIdWithAddressHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdWithAddressResult> Handle(GetByIdWithAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetByIdWithAddressValidator();
            var validatorResult = validator.Validate(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            var user = await _userRepository.GetByIdWithAddressAsync(request.Id, cancellationToken) ?? throw new KeyNotFoundException($"User ID {request.Id} not found.");

            var result = _mapper.Map<GetByIdWithAddressResult>(user);

            return result;
        }
    }
}
