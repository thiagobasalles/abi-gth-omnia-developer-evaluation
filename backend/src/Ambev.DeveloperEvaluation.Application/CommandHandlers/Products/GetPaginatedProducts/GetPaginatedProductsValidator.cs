using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetPaginatedProducts
{
    public class GetPaginatedProductsValidator : AbstractValidator<GetPaginatedProductsCommand>
    {
        private static readonly HashSet<string> AllowedFields = new(StringComparer.OrdinalIgnoreCase)
        {
            "title",
            "price",
            "description",
            "category",
            "image",
            "rating.rate",
            "rating.count"
        };

        public GetPaginatedProductsValidator()
        {
            RuleFor(x => x.Order)
                .Must(BeValidOrderClause)
                .WithMessage("Invalid order clause. Use format: 'price asc, rating.rate desc'. Fields must be allowed and directions must be asc/desc.");
        }

        private bool BeValidOrderClause(string? order)
        {
            if (string.IsNullOrWhiteSpace(order))
                return true;

            var clauses = order.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var clause in clauses)
            {
                var parts = clause.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    return false;

                var field = parts[0];
                var direction = parts[1].ToLower();

                if (!AllowedFields.Contains(field))
                    return false;

                if (direction != "asc" && direction != "desc")
                    return false;
            }

            return true;
        }
    }
}
