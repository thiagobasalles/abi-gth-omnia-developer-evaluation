using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByCategoryWithRating
{
    public class GetByCategoryWithRatingResult
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Caregory { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public GetByCategoryWithRatingRatingResult Rating { get; set; } = default!;
    }
}
