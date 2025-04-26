using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetPaginatedUsers
{
    public class GetPagintedUsersRequestValidator : AbstractValidator<GetPaginatedUsersRequest>
    {
        private static readonly HashSet<string> AllowedFields = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "id",
        "username",
        "email",
        "phone",
        "createdat",
        "updatedat",
        "role",
        "status",
        "address.city",
        "address.street",
        "address.zipcode",
        "address.number",
        "address.geolocation.lat",
        "address.geolocation.long"
    };

        public GetPagintedUsersRequestValidator()
        {
            RuleFor(x => x.Page)
                .NotEmpty()
                .WithMessage("Page is required");
            RuleFor(x => x.Size)
                .NotEmpty()
                .WithMessage("Size is required");
            RuleFor(x => x.Order)
                .Must(BeValidOrderClause)
                .WithMessage("Invalid order clause. Use format: 'username asc, email desc'. Fields must be allowed and directions must be asc/desc.");
        }

        private bool BeValidOrderClause(string? order)
        {
            if (string.IsNullOrWhiteSpace(order))
                return true;

            var clauses = order.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var clause in clauses)
            {
                var trimmed = clause.Trim();
                var parts = trimmed.Split(' ', StringSplitOptions.RemoveEmptyEntries);

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

