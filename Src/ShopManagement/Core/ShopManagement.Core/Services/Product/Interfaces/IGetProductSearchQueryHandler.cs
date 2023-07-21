using System.Threading;
using System.Threading.Tasks;

namespace ShopManagement.Core.Services.Product.Query
{
    public interface IGetProductSearchQueryHandler
    {
        Task<GetProductSearchQueryResponse> Handle(GetProductSearchQueryRequest request, CancellationToken cancellationToken);
    }
}
