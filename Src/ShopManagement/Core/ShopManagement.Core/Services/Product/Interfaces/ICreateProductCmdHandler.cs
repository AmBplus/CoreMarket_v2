using Base.Shared.ResultUtility;
using System.Threading.Tasks;
using System.Threading;
using ShopManagement.Core.Services.Product.Command;

namespace ShopManagement.Core.Services.Product.Interfaces
{
    public interface ICreateProductCmdHandler
    {
        Task<ResultOperation> Handle(CreateProductCmdRequest request, CancellationToken cancellationToken);
    }
}
