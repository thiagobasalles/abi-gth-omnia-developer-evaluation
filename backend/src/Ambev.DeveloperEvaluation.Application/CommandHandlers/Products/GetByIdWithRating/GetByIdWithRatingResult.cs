using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByIdWithRating
{
    public class GetByIdWithRatingResult
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Caregory { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public GetByIdWithRatingRatingResult Rating { get; set; } = default!;
    }
}
