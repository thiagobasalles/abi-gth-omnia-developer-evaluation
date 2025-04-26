using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetAllCategories
{
    public class GetAllCategoriesCommand : IRequest<IList<string>>
    {
    }
}
