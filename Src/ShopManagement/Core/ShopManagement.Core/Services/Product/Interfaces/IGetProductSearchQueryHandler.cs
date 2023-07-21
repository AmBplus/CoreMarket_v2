using ShopManagement.Core.Services.Product.DtoViewModel;
using System.Threading;
using System.Threading.Tasks;

namespace ShopManagement.Core.Services.Product.Query
{
    public interface IGetProductSearchQueryHandler
    {
        Task<ProductViewModel> Handle(GetProductSearchQueryRequest request, CancellationToken cancellationToken);
    }
}
