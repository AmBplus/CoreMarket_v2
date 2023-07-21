using Base.Shared.ResultUtility;
using ShopManagement.Core.Services.Product.DtoViewModel;
using ShopManagement.Core.Services.Product.Query;
using System.Threading;
using System.Threading.Tasks;

namespace ShopManagement.Core.Services.Product.Interfaces
{
    public interface IGetProductDetailQueryHandler
    {
        Task<ResultOperation<ProductDetailsDto>> Handle(GetProductDetailQueryRequest request, CancellationToken cancellationToken);
    }
}
