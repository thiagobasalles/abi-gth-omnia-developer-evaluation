using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Domain.Caches;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Contains unit tests for the <see cref="DeleteCartHandler"/> class.
    /// </summary>
    public class DeleteCartHandlerTests
    {
        private readonly ICartCacheService _cartCacheService;
        private readonly IMapper _mapper;
        private readonly DeleteCartHandler _handler;

        public DeleteCartHandlerTests()
        {
            _cartCacheService = Substitute.For<ICartCacheService>();
            _mapper = Substitute.For<IMapper>();
            _handler = new DeleteCartHandler(_cartCacheService, _mapper);
        }

        /// <summary>
        /// Tests that a valid cart ID results in a successful deletion.
        /// </summary>
        [Fact(DisplayName = "Given valid cart ID When deleting cart Then deletes from cache")]
        public async Task Handle_ValidId_DeletesCartFromCache()
        {
            // Given
            var command = new DeleteCartCommand(123);

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().NotThrowAsync();
            await _cartCacheService.Received(1).Delete(command.Id);
        }

        /// <summary>
        /// Tests that an invalid cart ID throws a validation exception.
        /// </summary>
        [Fact(DisplayName = "Given invalid cart ID When deleting cart Then throws validation exception")]
        public async Task Handle_InvalidId_ThrowsValidationException()
        {
            // Given
            var command = new DeleteCartCommand(0); // ID inválido

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<ValidationException>();
            await _cartCacheService.DidNotReceive().Delete(Arg.Any<long>());
        }
    }
}
