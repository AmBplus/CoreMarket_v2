using Base.Shared.ResultUtility;
using System.Threading.Tasks;
using System.Threading;

namespace ShopManagement.Core.Services.Product.Command
{
    public interface ICreateProductCmdHandler
    {
        Task<ResultOperation> Handle(CreateProductCmdRequest request, CancellationToken cancellationToken);
    }
}
